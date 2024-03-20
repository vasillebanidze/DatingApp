import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  userList: any;

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.getUserList();
  }

  public getUserList(): any {
    this.httpClient.get('http://localhost:5057/api/User').subscribe({
       next: value => this.userList = value,
     // next: (value) => console.log('Observable emitted the next value: ' + value),
      error: (err) => console.error('Observable emitted an error: ' + err),
      complete: () =>
        console.log('Observable emitted the complete notification'),
    });
  }
}
