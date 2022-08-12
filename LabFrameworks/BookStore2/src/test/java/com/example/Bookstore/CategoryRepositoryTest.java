package com.example.Bookstore;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;

import static org.assertj.core.api.Assertions.assertThat;
import com.example.Bookstore.model.*;
import com.example.Bookstore.repository.CategoryRepository;


@DataJpaTest
public class CategoryRepositoryTest {
	
	
	@Autowired
	 private CategoryRepository crepository; 
	
	 @Test
	 public void createNewCategory() {
		  
		 Category cat = new Category("Action");
		 this.crepository.save(cat);
		 assertThat(cat.getName()=="Action");
	}
	 @Test
	 public void searchCategory() {
		 Long id=1L;
		 Category cat = crepository.getById(id);			
		 assertThat(cat).isInstanceOf(Category.class);
	}
	 @Test
	 public void deleteCategory() {
		 Long id=1L;
		 crepository.deleteById(id);	
		 Boolean cat = crepository.existsById(id);
		 assertThat(cat);
	}
	 

}
