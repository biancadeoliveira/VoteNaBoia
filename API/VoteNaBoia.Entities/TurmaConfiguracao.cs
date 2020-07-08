using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Turma_Configuracoes")]
    public class TurmaConfiguracao
    {
        [Key]
        [Column("ID_Turma_Config")]
        public int IDTurmaConfig { get; private set; }

        [Required]
        [Column("ID_Turma")]
        public int IDTurma { get;  set; }

        [Required]
        [Column("SN_Segunda",TypeName ="char")]
        public char SNSegunda { get;  set; }

        [Required]
        [Column("SN_Terca", TypeName = "char")]
        public char SNTerca { get;  set; }
        [Required]
        [Column("SN_Quarta", TypeName = "char")]
        public char SNQuarta { get;  set; }
        [Required]
        [Column("SN_Quinta", TypeName = "char")]
        public char SNQuinta { get;  set; }
        [Required]
        [Column("SN_Sexta", TypeName = "char")]
        public char SNSexta { get;  set; }
        [Required]
        [Column("SN_Sabado", TypeName = "char")]
        public char SNSabado { get;  set; }

        [Required]
        [Column("NO_Restaurantes_Desc_VT_Semanal",TypeName = "int")]
        public int NORestaurantesDescVTSemanal { get; set; }

        [Required]
        [Column("NO_Dia_VT_Semanal", TypeName = "int")]
        public int NODiaVTSemanal { get; set; }

        [Required]
        [Column("DH_Inicio_VT_Semanal")]
        public TimeSpan DHInicioVTSemanal { get; set; }
        [Required]
        [Column("DH_Termino_VT_Semanal")]
        public TimeSpan DHTerminoVTSemanal { get; set; }
        [Required]
        [Column("DH_Inicio_VT_Diaria")]
        public TimeSpan DHInicioVTDiaria { get; set; }
        [Required]
        [Column("DH_Termino_VT_Diaria")]
        public TimeSpan DHTerminoVTDiaria { get; set; }

        protected TurmaConfiguracao() { }

        public TurmaConfiguracao(int idTurmaConfig, int idTurma, char snSegunda, char snTerca, char snQuarta, char snQuinta, char snSexta, char snSabado, int noRestauranteDescVTSemanal, int noDiaVTSemanal, TimeSpan dhInicioVTSemanal, TimeSpan dhTerminoVTSemanal, TimeSpan dhInicioVTDiaria, TimeSpan dhTerminoVTDiaria)
        {
            this.IDTurmaConfig = idTurmaConfig;
            this.IDTurma = idTurma;
            this.SNSegunda = snSegunda;
            this.SNTerca = snTerca;
            this.SNQuarta = snQuarta;
            this.SNQuinta = snQuinta;
            this.SNSexta = snSexta;
            this.SNSabado = snSabado;
            this.NORestaurantesDescVTSemanal = noRestauranteDescVTSemanal;
            this.NODiaVTSemanal = noDiaVTSemanal;
            this.DHInicioVTSemanal = dhInicioVTSemanal;
            this.DHTerminoVTSemanal = dhTerminoVTSemanal;
            this.DHInicioVTDiaria = dhInicioVTDiaria;
            this.DHTerminoVTDiaria = dhTerminoVTDiaria;
        }
         
    }
}
