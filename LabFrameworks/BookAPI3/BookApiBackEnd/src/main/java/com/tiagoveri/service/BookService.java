package com.tiagoveri.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.tiagoveri.model.Book;
import com.tiagoveri.repositories.BookRepository;

@Service
public class BookService {

	private final BookRepository bookRepo;

	public BookService(BookRepository bookRepo) {
		this.bookRepo = bookRepo;
	}
	
	public List<Book> findAll(){
		return bookRepo.findAll();
	}
	
	public Book findBookById(Long id) {
		return bookRepo.findById(id).orElse(null);
	}
	
	public Book saveBook(Book book) {
		return bookRepo.save(book);
	}
	
	public void deleteBook (Long id) {
		bookRepo.deleteById(id);
	}
	
	
}
