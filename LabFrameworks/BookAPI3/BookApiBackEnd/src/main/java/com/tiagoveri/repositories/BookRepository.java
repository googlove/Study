package com.tiagoveri.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.tiagoveri.model.Book;

public interface BookRepository extends JpaRepository<Book, Long> {

}
