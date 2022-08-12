package com.example.Bookstore;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;

import static org.assertj.core.api.Assertions.assertThat;

import java.util.Optional;

import com.example.Bookstore.model.*;
import com.example.Bookstore.repository.UserRepository;


@DataJpaTest
public class UserRepositoryTest {
	
	@Autowired
	 private UserRepository urepository;
	
	
	 @Test
	 public void createNewBook() {
		  
		 User user = new User("FrankRibery", "20dfssf4535gdg53324232334","User");
		 urepository.save(user);
		 assertThat(user.getUsername()=="FrankRibery");
	}
	 @Test
	 public void searchBook() {
		 String userName="user";
		 User user = urepository.findByUsername(userName);			
		 assertThat(user).isInstanceOf(User.class);
	}
	 @Test
	 public void deleteBook() {
		 Long id=1L;
		 urepository.deleteById(id);	
		 Boolean user = urepository.existsById(id);
		 assertThat(user);
	}
	 

}
