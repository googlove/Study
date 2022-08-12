package com.example.Bookstore.controller;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.example.Bookstore.model.Book;
import com.example.Bookstore.repository.BookStoreRepository;
import com.example.Bookstore.repository.CategoryRepository;

@Controller
public class BookController {

	@Autowired
	private BookStoreRepository bookRepository;
	@Autowired
	private CategoryRepository categoryRepository;
	List<Book> booksList = new ArrayList<>();

	@RequestMapping(value = "/login")
	public String login() {
		return "login";
	}
	
	@RequestMapping(value = "/logout")
	public String logout() {
		return "redirect:/login";
	}

	@GetMapping("/booklist")
	public String getIndex(Model model) {
		// booksList = (List<Book>) bookRepository.findAll();
		// model.addAttribute("books", booksList);
		model.addAttribute("books", bookRepository.findAll());

		return "booklist";
	}

	// Restful method to print all list of books as json.
	@GetMapping(value = "/books")
	public @ResponseBody List<Book> restFindBooks() {

		return bookRepository.findAll();

	}

	@GetMapping("/addbook")
	public String getBook(Model model) {
		Book book = new Book();
		model.addAttribute("book", book);
		model.addAttribute("categories", categoryRepository.findAll());
		return "addbook";
	}

	@PostMapping("/save")
	public String saveBook(@ModelAttribute("book") Book book, Model model) {

		bookRepository.save(book);
		return "redirect:/booklist";

	}

	@GetMapping("/edit/{id}")
	public String editBook(@PathVariable Long id, Model model) {

		Book book = bookRepository.getById(id);
		model.addAttribute("book", book);
		model.addAttribute("categories", categoryRepository.findAll());
		return "updatebook";
	}

	// A Restfull method to get a book by id
	@GetMapping("/books/{id}")
	public @ResponseBody Optional<Book> findBook(@PathVariable Long id) {

		return bookRepository.findById(id);
	}

	@PreAuthorize("hasAuthority('ADMIN')")
	@GetMapping("/delete/{id}")
	public String deleteBook(@PathVariable Long id) {

		bookRepository.deleteById(id);
		return "redirect:/booklist";

	}

}


 
