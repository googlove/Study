package com.example.Bookstore.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.Bookstore.model.Category;

public interface CategoryRepository extends JpaRepository<Category,Long> {
	
	/* List<Category> findByName(String name); */

}
