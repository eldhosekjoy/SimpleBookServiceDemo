import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SignatureHelpTriggerCharacter } from 'typescript';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html'
})
export class UpdateBookComponent {
    public book;
    public BookId:number = 2;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    
    putData(): Observable<number> {
        var headers = new HttpHeaders().set("Content-Type", "application/json; application/json; charset=utf-8");
        
        var sample: Book = {
            Id: this.BookId,
            BookName: "Updated Book",
            Author: "Author Updated",
            RegistrationTimeStamp: new Date(),
            Category: "Thriller",
            Description: "Test Description Updated"
        };
        var data = JSON.stringify(sample);
        
      
        return this.http.put<number>(this.baseUrl + 'api/book/'+sample.Id +'/update', data, { headers: headers });

    };
    onUpdateClick() {
        this.putData().subscribe(result => {
            this.book= result;
        }, error => console.error(error)
        );
    }
}

