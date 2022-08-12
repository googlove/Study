package com.example.Bookstore;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import com.example.Bookstore.model.Book;
import com.example.Bookstore.model.Category;
import com.example.Bookstore.repository.BookStoreRepository;
import com.example.Bookstore.repository.CategoryRepository;
import com.example.Bookstore.repository.UserRepository;
import com.example.Bookstore.model.User;



@SpringBootApplication
public class BookstoreApplication {
	private static final Logger log = LoggerFactory.getLogger(BookstoreApplication.class);

	public static void main(String[] args) {
		SpringApplication.run(BookstoreApplication.class, args);
	}

	@Bean
	public CommandLineRunner commandLineRunner(BookStoreRepository bookRepository, CategoryRepository categoryRepo,UserRepository urepository) {
		return args -> {

			Category cat1 = new Category("Drama");
			categoryRepo.save(cat1);
			Category cat2 = new Category("Thriller");
			categoryRepo.save(cat2);
			Category cat3 = new Category("Romance");
			categoryRepo.save(cat3);

			Book book1 = new Book("War and Peace", "Leo Tolstoy", "1895", "ISO89564777", cat1);
			bookRepository.save(book1);
			Book book2 = new Book("The count of Monte Cristo", "Alexander Dumas", "1844", "ISO89564777", cat3);
			bookRepository.save(book2);
			Book book3 = new Book("Rebecca", "Daphne du Maurier", "1938", "ISO89564777", cat2);
			bookRepository.save(book3);
			
			// Create users: admin/admin user/user
			
			  User user1 = new User("user",
			  "$2a$10$FTitFaX3rpxSX8yxF5UUMeV3TKWerl7mEQGTdL5ioO9zN11hvybzC", "USER"); User
			  user2 = new User("admin",
			  "$2a$10$IZohXY.II2cY.zp.RRHzveFC6tp02LMZAbUjrWOR.SdI04pU8foDu", "ADMIN");
			  User user3 = new User("guest",
			  "$2a$10$1loWr3UjodXznumrqLkCFOJoxprWNzE61S6FimPF.ZOHAbuW7Z1WG", "GUEST");
			  urepository.save(user1); urepository.save(user2); urepository.save(user3);
			  
			  log.info("fetch all users"); for (User user : urepository.findAll()) {
			  log.info(user.toString()); }
			 

		};
	}
}