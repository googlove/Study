import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../model/book';
import { BookService } from '../service/book.service';



@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent {

  book: Book;

  constructor(private route: ActivatedRoute, private router: Router,
    private bookService: BookService) {
    this.book = new Book();
  }

  onSubmit() {
    if (this.book.id == undefined) {
      this.bookService.saveBook(this.book).subscribe(result => this.gotoUserList());
    } else {
      this.bookService.editBook(this.book).subscribe(result => this.gotoUserList());
    }

  }

  gotoUserList() {
    this.router.navigate(['/books']);
  }

  // saveEditedBook(): void {
  //   this.bookService.editBook(this.book).subscribe(result => this.gotoUserList());
  // }




}
