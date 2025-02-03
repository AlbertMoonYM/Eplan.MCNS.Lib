using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib.UI_CS
{
    public class CS_PdfExport
    {
        public Control MakeSubject(string subjectTxt, Image image,int pnlWidth, int pnlHeight,int icoWidth, int icoHeight, Color pnlColor, Font lblFont)
        {
            // 이미지 PictureBox 설정
            PictureBox picBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage, // 이미지 크기에 맞게 자동 조정
                Size = new Size(icoWidth, icoHeight) // 원하는 이미지 크기로 설정
            };

            // 텍스트 Label 설정
            Label lblSubject = new Label
            {
                AutoSize = true,
                ForeColor = CS_StaticEtc.colors[0],
                Text = subjectTxt,
                Font = lblFont,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Panel 설정
            Panel pnlSubject = new Panel
            {
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = pnlColor,
                Size = new Size(pnlWidth, pnlHeight),
                Dock = DockStyle.None,
            };

            // PictureBox와 Label의 위치 설정
            picBox.Location = new Point(0, (pnlSubject.Height - picBox.Height) / 2); // Panel의 중앙에 맞추기
            lblSubject.Location = new Point(picBox.Right + 5, (pnlSubject.Height - lblSubject.Height) / 2); // 이미지 오른쪽에 위치, 이미지와의 간격 5픽셀

            // Panel에 PictureBox와 Label 추가
            pnlSubject.Controls.Add(picBox);
            pnlSubject.Controls.Add(lblSubject);

            return pnlSubject;
        }

        public void PreviewPdf(FlowLayoutPanel targetFpnl, Control[] exportCtrls)
        {
            
            int yOffset = 0;
            int maxPanelHeight = 1060; 
            int maxPanelwidth = 750; 

            // 초기 패널 생성 및 설정
            Panel pnlPdfPreview = new Panel
            {
                Size = new Size(maxPanelwidth, maxPanelHeight),
                AutoSize = false,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle

            };

            targetFpnl.Controls.Add(pnlPdfPreview);

            for (int i = 0; i < exportCtrls.Length; i++)
            {
                // 컨트롤의 비트맵 생성 및 크기 조정
                Bitmap originalBitmap = new Bitmap(exportCtrls[i].Width, exportCtrls[i].Height);
                exportCtrls[i].DrawToBitmap(originalBitmap, new Rectangle(0, 0, exportCtrls[i].Width, exportCtrls[i].Height));

                float scaleFactor = (float)pnlPdfPreview.Width / originalBitmap.Width;
                int newWidth = pnlPdfPreview.Width -2 ;
                int newHeight = (int)(originalBitmap.Height * scaleFactor);

                Bitmap resizedBitmap = new Bitmap(originalBitmap, new Size(newWidth, newHeight));

                // PictureBox 생성
                PictureBox pictureBox = new PictureBox
                {
                    Image = resizedBitmap,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Size = new Size(newWidth, newHeight),
                    Location = new Point(0, yOffset)
                };

                // 패널의 현재 높이를 초과하면 새 패널을 생성
                if (yOffset + pictureBox.Height > maxPanelHeight)
                {
                    // 새 패널 생성 및 설정
                    pnlPdfPreview = new Panel
                    {
                        Size = new Size(maxPanelwidth, maxPanelHeight),
                        AutoSize = false,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // 새 패널을 targetFpnl에 추가
                    targetFpnl.Controls.Add(pnlPdfPreview);

                    // Y 오프셋 초기화
                    yOffset = 0;

                    // 새로운 PictureBox의 위치 업데이트
                    pictureBox.Location = new Point(0, yOffset);
                }

                // 현재 패널에 PictureBox 추가
                pnlPdfPreview.Controls.Add(pictureBox);

                // 원본 비트맵 리소스 해제
                originalBitmap.Dispose();

                // Y 오프셋 증가
                yOffset += pictureBox.Height;
            }
        }
    }
}
