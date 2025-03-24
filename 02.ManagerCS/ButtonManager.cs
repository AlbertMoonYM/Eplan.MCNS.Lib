using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Eplan.MCNS.Lib
{    
    public class ButtonManager
    {
        // 이전 폴더 경로만 저장하는 변수
        private string lastFolderPath = string.Empty;

        public void FolderFinder(SimpleButton btn, ComboBoxEdit cb)
        {
            btn.Click += (o, e) =>
            {
                using (CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog())
                {
                    commonOpenFileDialog.IsFolderPicker = true;
                    commonOpenFileDialog.Title = "폴더 선택하기";

                    // 이전에 선택한 폴더 경로가 있으면 설정
                    if (!string.IsNullOrEmpty(lastFolderPath))
                    {
                        commonOpenFileDialog.InitialDirectory = lastFolderPath;
                    }

                    if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        cb.Text = commonOpenFileDialog.FileName;
                        cb.Select();

                        // 선택한 폴더 경로 저장
                        lastFolderPath = commonOpenFileDialog.FileName;
                    }
                }
            };
        }

        public void FileFinder(SimpleButton btn, ComboBoxEdit cb, string initPath, string filter)
        {
            btn.Click += (o, e) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // 파일 선택 시 폴더 경로만 기억하므로 lastFolderPath를 사용
                    openFileDialog.InitialDirectory = !string.IsNullOrEmpty(lastFolderPath) ? lastFolderPath : initPath;
                    openFileDialog.Filter = filter;
                    openFileDialog.Title = "파일 선택하기";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        cb.Text = openFileDialog.FileName;
                        cb.Select();

                        // 파일 경로는 저장하지 않고 폴더 경로만 기억
                        lastFolderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                    }
                }
            };
        }

    }
}
