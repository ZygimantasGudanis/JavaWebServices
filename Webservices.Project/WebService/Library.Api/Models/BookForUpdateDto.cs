using System.ComponentModel.DataAnnotations;

namespace Library.Api.Models
{
    public class BookForUpdateDto : BookForManipulationDto
    {
        [Required(ErrorMessage ="You should fill out a description")]
        public override string Description
        {
            get
            {
                return base.Description;
            }

            set
            {
                base.Description = value;
            }
        }

        public void Update(Book book)
        {
            book.Title = Title;
            book.Description = Description;
        }
    }
}
