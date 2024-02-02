using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManagerCommon.ViewModels
{
    public class CreateUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ввелите название")]
        [StringLength(45, ErrorMessage = "Длина названия не может превышать 45 символов")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Длина описания не может превышать 500 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберите статус")]
        public int StatusId { get; set; }
    }
}
