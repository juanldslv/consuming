using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ejemplo
{
    public class DetailBookViewModel: ViewModelBase
    {

        public BookDetail bookDetail { get; set; }

        private readonly IRequest _request;
        public string ISB;
        public DetailBookViewModel(IRequest request)
        {

            if (request == null) throw new System.ArgumentNullException(nameof(request));
            {
                _request = request;
            }

            if (!IsInDesignMode)
            {
                bookDetail = new BookDetail();


            }

        }
        public async Task<BookDetail> GetDetailBook(string isbn13)
        {

            var items = await _request.GetDetailBook(isbn13);
            bookDetail = new BookDetail();
            bookDetail = items;
            return bookDetail;
        }


    }
}
