using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19France.Models
{
    public class Data
    {
        public string Nom { get; set; }
        public string Code { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Gueris { get; set; }
        public int CasConfirmes { get; set; }
        public int Hospitalises { get; set; }
        public int Reanimation { get; set; }
        public int Deces { get; set; }
        public int NouvellesHospitalisations { get; set; }
        public int NouvellesReanimations { get; set; }
        public int CasConfirmesEhpad { get; set; }
        public int DecesEhpad { get; set; }
    }
}
