using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RoboSalesSoftWare
{
    public  class InsertData
    {
        public static string SetDataForUsers() {
            var insertQuery = new StringBuilder();

                insertQuery.AppendLine($"IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserCode = 1 ) BEGIN");
                insertQuery.AppendLine("SET IDENTITY_INSERT [dbo].[Users] ON");

                insertQuery.AppendLine($"INSERT [dbo].[Users] ([UserCode], [UserName], [PassWord]) VALUES (1, N'1234', N'1234') END");
                insertQuery.AppendLine("SET IDENTITY_INSERT [dbo].[Users] OFF");

            insertQuery.AppendLine("GO");

            return insertQuery.ToString();
        }
    }
}
