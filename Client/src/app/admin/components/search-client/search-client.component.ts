import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from 'src/app/http.service';
import { Users } from '../../Models/Users';

@Component({
  selector: 'app-search-client',
  templateUrl: './search-client.component.html',
  styleUrls: ['./search-client.component.scss']
})
export class SearchClientComponent implements OnInit {

  constructor(private http: HttpService, private formBuilder: FormBuilder) {
    this.searchForm = this.formBuilder.group({
      option: ['', Validators.required],
      text: ['', Validators.required],
    })
  }

  users$: Observable<any[]>
  history$: any;
  isClicked: boolean;

  optionSelected: string;
  userSelected: Users;
  searchForm: FormGroup;
  Options = ['name', 'userName'];

  async ngOnInit(): Promise<void> {
    this.isClicked = false;
    this.users$ = this.GetAllUsers();
  }

  GetAllUsers(): Observable<any[]> {
    return this.http.GetAllUsers();
  }

  BtnClick() {
    this.http.GetUserHistory(this.userSelected.id).subscribe(data => {
      this.history$ = data;
    });
    this.isClicked = true;
  }
}
