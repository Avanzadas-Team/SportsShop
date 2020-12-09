import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/http.service';
import { Users } from '../../Models/Users';

@Component({
  selector: 'app-common-clients',
  templateUrl: './common-clients.component.html',
  styleUrls: ['./common-clients.component.scss']
})
export class CommonClientsComponent implements OnInit {

  constructor(private http: HttpService, private formBuilder: FormBuilder) {
    this.searchForm = this.formBuilder.group({
      option: ['', Validators.required],
      text: ['', Validators.required],
    })
  }

  users$: Observable<any[]>
  common$: any;
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
    console.log(this.userSelected.id)
    this.http.GetClientsInCommon(this.userSelected.id).subscribe(data => {
      this.common$ = data;
    });
    this.isClicked = true;
  }

}
