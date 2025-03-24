using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace Eplan.MCNS.Lib
{
    public class GroupControlManager
    {
        /// <summary>
        /// 그룹박스 최대화, 최소화 size(120,25)
        /// </summary>
        /// <param name="grp">GroupControl 인스턴스</param>
        public void SpreadGroupControl(GroupControl grp, Image openImage, Image closeImage)
        {
            // 이미지 크기 조정 (예: 20x20 픽셀로 조정)
            Image resizedOpenImage = ResizeImage(openImage, 10, 6);
            Image resizedCloseImage = ResizeImage(closeImage, 6, 10);

            // 버튼 객체 생성
            GroupBoxButton unCheckBtn = new GroupBoxButton
            {
                Caption = "",
                ImageOptions = { Image = resizedCloseImage }, // 기본 이미지
                Tag = "UnChecked" // 상태 식별용
            };
            GroupBoxButton checkBtn = new GroupBoxButton
            {
                Caption = "",
                ImageOptions = { Image = resizedOpenImage }, // 체크 상태 이미지
                Tag = "Checked" // 상태 식별용
            };

            // 기본적으로 체크되지 않은 상태로 시작
            grp.CustomHeaderButtons.Add(checkBtn);
            // 원래 크기 저장
            Size originalSize = grp.Size;

            // 버튼 클릭 이벤트 핸들러
            grp.CustomButtonClick += (o, e) =>
            {
                GroupBoxButton button = e.Button as GroupBoxButton;
                if (button != null)
                {
                    // 상태에 따라 크기와 이미지 변경
                    if (button.Tag.ToString() == "UnChecked")
                    {
                        grp.Size = originalSize;
                        button.ImageOptions.Image = resizedOpenImage;
                        button.Caption = "";
                        button.Tag = "Checked";
                    }
                    else
                    {
                        grp.Size = new Size(grp.Width, 25);
                        button.ImageOptions.Image = resizedCloseImage;
                        button.Caption = "";
                        button.Tag = "UnChecked";
                    }
                }
            };
        }
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }
    }
}