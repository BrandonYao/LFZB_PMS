using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LFZB_PMS.DAL
{
    public class MessageDAL
    {
        /// <summary>
        /// 显示通知
        /// </summary>
        /// <param name="info">通知文本</param>
        public void ShowInfo(string info)
        {
            MessageBox.Show(info, "系统消息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 显示错误
        /// </summary>
        /// <param name="warning">错误文本</param>
        public void ShowWarning(string warning)
        {
            MessageBox.Show(warning, "系统消息", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示确认提示框
        /// </summary>
        /// <param name="question">提问内容</param>
        /// <returns>Yes/No</returns>
        public bool ShowQuestion(string question)
        {
            bool result = false;
            if (MessageBox.Show(question, "系统消息", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                result = true;
            }
            return result;
        }
    }
}
