using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Resizr
{
    public partial class ResizrForm : Form
    {

        delegate void SetProgressBarCallback(int value);
        delegate string GetDropdownValueCallback();
        delegate void CloseFormCallback();

        string[] extensions = new string[] { ".jpg", ".gif", ".bmp", ".png" };

        public int deltaX;
        public int deltaY;

        public bool isMouseDown = false;
        public ResizrForm()
        {
            InitializeComponent();
            ContextMenu mnuContext = new ContextMenu();
            mnuContext.MenuItems.Add(new MenuItem("&Paste", new EventHandler(mnuContextPaste_Click))); 
            this.ContextMenu = mnuContext;
        }

        private void mnuContextPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsFileDropList())
            {
                StringCollection files = Clipboard.GetFileDropList();

                StartProcessingThread(files);

            }
        }

        private void lblDrop_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
            }
        }

        private void lblDrop_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the
            // foreach loop in place of "files", but this is easier to understand.)
            StringCollection files = ConvertStringArrayToCollection((string[])e.Data.GetData(DataFormats.FileDrop));

            StartProcessingThread(files);
        }

        private void StartProcessingThread(StringCollection files)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.ShowDialog();
            string SelectedFolder = dlgFolder.SelectedPath;

            ProcessingData procData = new ProcessingData();
            procData.Files = files;
            procData.OutputFolder = SelectedFolder;

            prgStatus.Maximum = files.Count;

            Thread procThread = new Thread(new ParameterizedThreadStart(ProcessFiles));
            procThread.Start(procData);
        }

        private void ProcessFiles(object fileObject)
        {
            StringCollection files = ((ProcessingData)fileObject).Files;
            string outputFolder = ((ProcessingData)fileObject).OutputFolder;

            int maxSize = 0;

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (extensions.Contains(fi.Extension.ToLower()))
                {
                    switch (GetDropdownValue())
                    {
                        case "Thumbnail (120)":
                            maxSize = 120;
                            break;
                        case "Email (800px)":
                            maxSize = 800;
                            break;
                        case "Facebook (1024px)":
                            maxSize = 1024;
                            break;
                        case "Flickr (1600px)":
                            maxSize = 1600;
                            break;
                        case "Flickr (2400px)":
                            maxSize = 2400;
                            break;
                        default:
                            maxSize = 320;
                            break;
                    }

                    ImageManipulation.ResizeImage(fi.FullName, outputFolder + "\\" + maxSize.ToString() + "_" + fi.Name, maxSize);
                }

                IncrementProgress(1);
            }

            MessageBox.Show(files.Count + " files converted!", "All done!");
            Process.Start(new ProcessStartInfo(outputFolder));
            CloseForm();
        }

        private void IncrementProgress(int value)
        {
            if (this.prgStatus.InvokeRequired)
            {
                SetProgressBarCallback pbCallback = new SetProgressBarCallback(IncrementProgress);
                this.Invoke(pbCallback, new object[] { value });
            }
            else
            {
                this.prgStatus.Value += value;
                this.prgStatus.Refresh();
            }
        }

        private string GetDropdownValue()
        {
            if (this.cboSize.InvokeRequired)
            {
                GetDropdownValueCallback ddCallback = new GetDropdownValueCallback(GetDropdownValue);
                return (string)this.Invoke(ddCallback, new object[]{});
            }
            else
            {
                return this.cboSize.SelectedItem.ToString();
            }
        }

        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                CloseFormCallback cfCallback = new CloseFormCallback(CloseForm);
                this.Invoke(cfCallback, new object[] { });
            }
            else
            {
                this.Close();
            }
        }

        private StringCollection ConvertStringArrayToCollection(string[] array)
        {
            StringCollection retVal = new StringCollection();
            foreach (string s in array)
            {
                retVal.Add(s);
            }
            return retVal;
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {

            deltaX = Form.MousePosition.X - Form.ActiveForm.Location.X;
            deltaY = Form.MousePosition.Y - Form.ActiveForm.Location.Y;
            isMouseDown = true;
        }

        private void MoveForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                Point p = new Point(MousePosition.X - deltaX, MousePosition.Y - deltaY);
                Form.ActiveForm.Location = p;
            } 
        }

        private void MoveForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false; 
        }

        private void cboSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseForm();
            }
        }

        private void ResizrForm_Load(object sender, EventArgs e)
        {
            cboSize.SelectedItem = cboSize.Items[2];
        }

    }
}
