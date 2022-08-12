package com.example.Bookstore;


import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.factory.PasswordEncoderFactories;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.util.matcher.AntPathRequestMatcher;

import com.example.Bookstore.service.UserDetailServiceImpl;

/*import com.example.Bookstore.service.UserDetailServiceImpl;*/


@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true)
public class WebSecurityConfig extends WebSecurityConfigurerAdapter {
	
	
	  @Autowired UserDetailServiceImpl userDetailsService;
	 
	
	private final PasswordEncoder passwordEncoder;
	
	@Autowired
    public WebSecurityConfig(PasswordEncoder passwordEncoder) {		
		this.passwordEncoder = passwordEncoder;
	}




	@Override
    protected void configure(HttpSecurity http) throws Exception {
        http
        .authorizeRequests().antMatchers("/css/**").permitAll() // Enable css when logged out
        .and()
        .logout()
        .and()
        .authorizeRequests().anyRequest().authenticated()        
        .and()
        
      .formLogin()
	      .loginPage("/login")
	      .permitAll()
          .defaultSuccessUrl("/booklist", true)
          .permitAll()
        .and()
        .logout()
        	.logoutUrl("/logout")
	        .permitAll()
	        .logoutRequestMatcher(new AntPathRequestMatcher("/logout", "POST"))
        	.clearAuthentication(true)
        	.invalidateHttpSession(true)
        	.deleteCookies("JSESSIONID", "remember-me")
        	.logoutSuccessUrl("/login");
      
        
    }
    
    
    
    
	// Uses users data from the database
	
	  @Autowired public void configureGlobal(AuthenticationManagerBuilder auth)
	  throws Exception {
	  auth.userDetailsService(userDetailsService).passwordEncoder(new
	  BCryptPasswordEncoder()); }
	 
	 
	  
	  

	// uses data from InMemoryUserDetailsManager
	
	/*
	 * @Bean
	 * 
	 * @Override public UserDetailsService userDetailsService() { List<UserDetails>
	 * users = new ArrayList(); UserDetails user1 = User.builder() .username("user")
	 * .password(passwordEncoder.encode("user")) .roles("USER") .build();
	 * 
	 * users.add(user1);
	 * 
	 * UserDetails user2 = User.builder(). username("admin")
	 * .password(passwordEncoder.encode("admin")) .roles("USER", "ADMIN") .build();
	 * 
	 * users.add(user2);
	 * 
	 * return new InMemoryUserDetailsManager(users); }
	 */
	 
	 
}
