import { Component, OnInit } from '@angular/core';
import { Book } from '../model/book';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  books: Book[];
  constructor(private bookService: BookService) { }


  ngOnInit() {
    this.bookService.getAllBooks().subscribe(books => {
      this.books = books;
      console.log(books);
    });
  }

  deleteBook(book: Book): void {
    this.bookService.deleteBook(book).subscribe(data => {
      this.books = this.books.filter(u => u !== book)
    });
  }

}
