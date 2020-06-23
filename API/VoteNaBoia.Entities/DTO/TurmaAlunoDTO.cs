/*
 * Author: Bianca Oliveira
 * Date: 2020/06/18
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class TurmaAlunoDTO
    {
        public int IDTurmaAluno { get; set; }
        public int IDAluno { get; set; }
        public int IDTurma { get; set; }
        public DateTime DTVinculo { get; set; }
        public char SNAprovado { get; set; }
        public char SNModerador { get; set; }
    }
}
