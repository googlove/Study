import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './book-list/book.component';
import { BookFormComponent } from './book-form/book-form.component';

const routes: Routes = [
    { path: 'books', component: BookComponent },
    { path: 'insertBook', component: BookFormComponent },
    { path: 'editBook/:id', component: BookFormComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }