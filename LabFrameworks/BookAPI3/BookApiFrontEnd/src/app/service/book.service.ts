import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { Book } from '../model/book';


const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable()
export class BookService {


    private bookUrl: string;
    constructor(private _httpService: HttpClient) {
        this.bookUrl = 'http://localhost:8080/books';
    }


    getAllBooks(): Observable<Book[]> {
        return this._httpService.get<Book[]>(this.bookUrl);

    }
    saveBook(book: Book) {
        return this._httpService.post<Book>(this.bookUrl, book);
    }

    deleteBook(book: Book) {
        return this._httpService.delete<Book>(this.bookUrl + "/" + book.id);
    }

    editBook(book: Book) {
        const url = `${this.bookUrl}/${book.id}`;
        return this._httpService.put<Book>(url, book, httpOptions);
    }
}