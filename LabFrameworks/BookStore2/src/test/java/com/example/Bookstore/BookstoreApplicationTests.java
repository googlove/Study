package com.example.Bookstore;
import  com.example.Bookstore.controller.*;

import org.springframework.beans.factory.annotation.*;
import static org.assertj.core.api.Assertions.assertThat;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class BookstoreApplicationTests {
	@Autowired
	private BookController bcontroller;

	@Test
	void contextLoads() {
		assertThat(bcontroller).isNotNull();
	}

}
