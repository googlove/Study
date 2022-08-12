package com.tiagoveri.controller;

import java.net.URI;
import java.util.List;

import javax.validation.Valid;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import com.tiagoveri.model.Book;
import com.tiagoveri.service.BookService;

@CrossOrigin("*")
@RestController
@RequestMapping(value= "/books")
public class BookController {

	private final BookService bookservice;

	public BookController(BookService bookservice) {
		this.bookservice = bookservice;
	}
	
	@GetMapping(value="/{id}")
	public ResponseEntity<Book> findBookById(@PathVariable Long id){
		Book obj = bookservice.findBookById(id);
		return ResponseEntity.ok().body(obj);
	}
	
	@GetMapping
	public ResponseEntity<List<Book>> findAllBooks(){
		List<Book> books = bookservice.findAll();
		return ResponseEntity.ok().body(books);
	}
	
	@PostMapping
	public ResponseEntity<Void> insertBook(@Valid @RequestBody Book book){
		book = bookservice.saveBook(book);
		URI uri = ServletUriComponentsBuilder.fromCurrentRequest()
				.path("/{id}").buildAndExpand(book.getId()).toUri();
		return ResponseEntity.created(uri).build();
	}
	
	@PutMapping(value= "/{id}")
	public ResponseEntity<Void> updateBook(@Valid @RequestBody Book book, @PathVariable Long id){
		book.setId(id);
		book = bookservice.saveBook(book);
		return ResponseEntity.noContent().build();
	}
	
	@DeleteMapping(value= "/{id}")
	public ResponseEntity<Void> deleteBook(@PathVariable Long id){
		bookservice.deleteBook(id);
		return ResponseEntity.noContent().build();
	}
	
	
}
