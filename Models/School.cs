using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class School
    {
        public int id { get; set; }
        public DateTime data_extracao { get; set; }
        public string dep_administrativa { get; set; }
        public string tipo { get; set; }
        public int inep { get; set; }
        public string nome { get; set; }
        public string abr_nome { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public int cep { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string url_website { get; set; }
        public string blog { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public int reg_conselho_tutelar { get; set; }
        public string desc_reg_conselho_tutelar { get; set; }
        public int reg_orcamento_part { get; set; }
        public string desc_reg_orcamento_part { get; set; }
        public string situacao_funcionamento { get; set; }
        public string convenio_municipal { get; set; }
        public string convenio_estadual { get; set; }
        public string convenio_federal { get; set; }
        public string convenio_fasc { get; set; }
        public string escola_especial { get; set; }
        public string cat_part_privada { get; set; }
        public string cat_part_comunitaria { get; set; }
        public string cat_part_confessional { get; set; }
        public string cat_part_filantropica { get; set; }
        public string mant_empresa_privada { get; set; }
        public string mant_sindicato { get; set; }
        public string mant_sistema_s { get; set; }
        public string mant_ong { get; set; }
        public string mant_apae { get; set; }

    }
}


