package com.example.Bookstore;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;

import static org.assertj.core.api.Assertions.assertThat;
import com.example.Bookstore.model.*;
import com.example.Bookstore.repository.BookStoreRepository;
import com.example.Bookstore.repository.CategoryRepository;

@DataJpaTest
public class BookStoreRepositoryTest {
	
	@Autowired
	 private BookStoreRepository brepository;
	@Autowired
	 private CategoryRepository crepository; 
	
	 @Test
	 public void createNewBook() {
		  
		 Book book = new Book("Of Mice and Men","Frank Ribery", "1975","ISO345635554",crepository.findAll().get(0));
		 this.brepository.save(book);
		 assertThat(book.getTitle()=="Of Mice and Men");
	}
	 @Test
	 public void searchBook() {
		 Long id=52L;
		 Book book = brepository.getById(id);			
		 assertThat(book).isInstanceOf(Book.class);
	}
	 @Test
	 public void deleteBook() {
		 Long id=52L;
		 brepository.deleteById(id);	
		 Boolean deleted = brepository.existsById(id);
		assertThat(deleted);
	}
	 

}
