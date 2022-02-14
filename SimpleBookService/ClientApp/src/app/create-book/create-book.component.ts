import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SignatureHelpTriggerCharacter } from 'typescript';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html'
})
export class CreateBookComponent {
    public BookId: number;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    postData():Observable<number> {
        var headers = new HttpHeaders().set("Content-Type", "application/json; application/json; charset=utf-8");
        
        var sample: Book = {
            Id: 0,
            BookName: "Test Book",
            Author: "Author1",
            RegistrationTimeStamp: new Date(),
            Category: "Thriller",
            Description: "Test Description"
        };
        var data = JSON.stringify(sample);
        alert(this.baseUrl + 'api/book/create');

         return this.http.post<number>(this.baseUrl + 'api/book/create', data, {headers:headers});
        
    };
    onCreateClick() {
        this.postData().subscribe(result => {
            this.BookId = result;
        }, error => console.error(error)
        );
    }
}


