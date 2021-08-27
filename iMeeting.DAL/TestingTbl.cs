using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    [Table("Testing")]
   public class TestingTbl
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
    }
}
