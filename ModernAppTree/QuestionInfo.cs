using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernAppTree
{
  public class QuestionInfo
  {
    public string Title { get; set; }
    public string Question { get; set; }
    public QuestionInfo NoAnswer { get; set; }
    public QuestionInfo YesAnswer { get; set; }
  }
}
