using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Models
{
    

    public class Player
    {
        //To store the player jersey no.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int P_Jno { get; set; }

        //To store the player name.
        public string P_Name { get; set; }

        //To store the player age.
        public int P_Age { get; set; }

        //To store the player category.
        public string P_Category { get; set; }

    }
}
