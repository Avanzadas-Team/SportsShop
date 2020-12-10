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
    this.usrID = this.GetUsrID();
    this.GetHistory(this.usrID);
  }

  GetUsrID(): string {
    var id = "5fd03cbfa914d9ca441859a8"
    return id;
  }
  GetHistory(id: string): void {
    this.http.GetUserHistory(id).subscribe(data => {
      this.prods$ = data;
    });
  }
}
