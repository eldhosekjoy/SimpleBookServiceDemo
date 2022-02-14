import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignatureHelpTriggerCharacter } from 'typescript';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public books;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
       
      http.get<Book[]>(baseUrl + 'api/book').subscribe(result => {
          this.books = result;
          console.log(this.books);
    }, error => console.error(error));
  }
}


