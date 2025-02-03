using Eplan.MCNS.Lib.Share_CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib.UI_CS
{
    public class CS_PathCheck
    {
        /*
        public string[] SaveFilesPath(string folderPath, string filterStr)
        {
            // 폴더 경로가 존재하지 않는 경우 메시지 출력 후 빈 배열 반환
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"폴더 경로가 존재하지 않습니다: {folderPath}");
                return Array.Empty<string>();
            }

            // 지정된 폴더에서 .emp 파일 경로 배열 가져오기
            string[] filesPaths = Directory.GetFiles(folderPath, "*.emp");

            // 파일이 없는 경우 메시지 출력 후 빈 배열 반환
            if (filesPaths.Length == 0)
            {
                MessageBox.Show($"폴더에 매크로 파일이 없습니다: {folderPath}");
                return Array.Empty<string>();
            }

            // 필터 문자열에 따라 파일 경로 필터링
            string[] filteredFiles = string.IsNullOrEmpty(filterStr)
                ? filesPaths // 필터가 없으면 모든 파일 반환
                : filesPaths.Where(file => Path.GetFileName(file).StartsWith(filterStr)).ToArray();

            // 필터에 매칭되는 파일이 없는 경우 메시지 출력 후 빈 배열 반환
            if (filteredFiles.Length == 0)
            {
                MessageBox.Show($"폴더에 매칭되는 매크로 파일이 없습니다: {filterStr}");
            }

            return filteredFiles; // 필터된 파일 배열 반환
        }
        */
        public string[] SaveFilesPath(string folderPath, string filterStr)
        {
            // 폴더 경로가 존재하지 않는 경우 메시지 출력 후 빈 배열 반환
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"폴더 경로가 존재하지 않습니다: {folderPath}");
                return Array.Empty<string>();
            }

            // 지정된 폴더에서 .emp 파일 경로 배열 가져오기
            string[] filesPaths = Directory.GetFiles(folderPath, "*.emp");

            // 파일이 없는 경우 메시지 출력 후 빈 배열 반환
            if (filesPaths.Length == 0)
            {
                MessageBox.Show($"폴더에 매크로 파일이 없습니다: {folderPath}");
                return Array.Empty<string>();
            }

            string[] filteredFiles; // 필터링된 파일 배열 초기화

            // 필터 문자열에 따라 파일 경로 필터링
            if (string.IsNullOrEmpty(filterStr))
            {
                filteredFiles = filesPaths; // 필터가 없으면 모든 파일 반환
            }
            else
            {
                filteredFiles = filesPaths
                    .Where(file => Path.GetFileName(file).StartsWith(filterStr))
                    .ToArray();
            }

            // 필터에 매칭되는 파일이 없는 경우 메시지 출력 후 빈 배열 반환
            if (filteredFiles.Length == 0)
            {
                MessageBox.Show($"폴더에 매칭되는 매크로 파일이 없습니다: {filterStr}");
            }
            /*
            // 경로 저장 값 확인
            // 메시지를 줄바꿈으로 구분하여 하나의 문자열로 만듭니다.
            string message = string.Join(Environment.NewLine, filteredFiles);

            // 메시지 박스 출력
            MessageBox.Show(message, "메시지", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            return filteredFiles; // 필터된 파일 배열 반환
        }



        public void CheckFilePath(string filePath, string dataName)
        {
            if (File.Exists(filePath))
            {

            }
            else
            {
                MessageBox.Show(dataName + " 경로가 올바르지 않습니다 : " + filePath);
                return;
            }
        }

        public void CheckFoldePath(string folderPath, string dataName)
        {
            if (Directory.Exists(folderPath))
            {

            }
            else
            {
                MessageBox.Show(dataName + " 경로가 올바르지 않습니다 : " + folderPath);
                return;
            }
        }
    }
}
