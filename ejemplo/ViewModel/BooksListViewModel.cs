using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace ejemplo
{
    public class BooksListViewModel : ViewModelBase
    {
       
        public List<BookElement> Books { get; set; }

        private readonly IRequest _request;

        public BooksListViewModel(IRequest request)
        {

            if (request == null) throw new System.ArgumentNullException(nameof(request));
            {
                _request = request;
            }

            if (!IsInDesignMode)
            {
                Books = new List<BookElement>();
                
            }

        }

        public async Task<List<BookElement>> InitAsync()
        {
            List<BookElement> books = await _request.GetBooks();

            Books.Clear();
            foreach (var item in books)
            {
                Books.Add(item);
            }

            return Books ;

        }
        public async Task<List<BookElement>> GetBook(string bookname)
        {
            var items = await _request.GetBook(bookname);

            Books.Clear();
            foreach (var item in items)
            {
                Books.Add(item);
            }
            return Books;

        }
       
    }
}