using System.Text;

namespace PDF_API.Api.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>
                                    <tr>
                                    <td>abcd</td>
                                    <td>abcd</td>
                                    <td>abcd</td>
                                    <td>abcd</td>
                                  </tr>"); 
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
 
            return sb.ToString();
        }
    }
}
