import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-client-history',
  templateUrl: './client-history.component.html',
  styleUrls: ['./client-history.component.scss']
})
export class ClientHistoryComponent implements OnInit {


  constructor(private http: HttpService) { }

  usrID: string;
  prods$: any;

  ngOnInit(): void {
    this.usrID = localStorage.getItem("id");
    this.GetHistory(this.usrID);
  }
  
  GetHistory(id: string): void {
    this.http.GetUserHistory(id).subscribe(data => {
      this.prods$ = data;
    });
  }
}
