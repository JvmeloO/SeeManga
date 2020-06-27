﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Models.Model
{
    public class MangasModel
    {
        [Key]
        public int ID_MANGA { get; set; }

        [Required]
        [MaxLength(150)]
        public string TITULO { get; set; }

        [Required]
        [MaxLength(2500)]
        public string SINOPSE { get; set; }

        [Required]
        public byte[] CAPA { get; set; }

        [Required]
        public int ID_SITUACAO { get; set; }

        public virtual SituacoesModel Situacao { get; set; }

        public virtual ICollection<Manga_GenerosModel> Manga_generos { get; set; }

        public virtual ICollection<CapitulosModel> Capitulos { get; set; }

        public virtual ICollection<ComentariosModel> Comentarios { get; set; }

    }
}
