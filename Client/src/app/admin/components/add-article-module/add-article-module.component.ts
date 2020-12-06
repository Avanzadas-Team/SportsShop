import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-article-module',
  templateUrl: './add-article-module.component.html',
  styleUrls: ['./add-article-module.component.scss']
})
export class AddArticleModuleComponent implements OnInit {

  constructor(private service: HttpService) { }

  aname : string;

  brand : string;

  price : number;

  sport : string;

  edition :string;

  stock :number;

  sports: string[] = [];

  image : File;

  type: string;

  edit: boolean;

  info;

  response;

  ngOnInit(): void {
  }

  addSport(){
    this.sports.push(this.sport);
  }

  onEditionChange(){
    if(this.edition == "Yes"){
      this.edit = true;
    }else{
      this.edit = false;
    }
  }

  addArticle(){

    this.info = {
      Name: this.aname,
      Make: this.brand,
      Price: this.price,
      sports: this.sports,
      limitEd: this.edit,
      Type: this.type,
      ImageId: ""
    }
    this.service.postArticle(this.info).subscribe(r => {
      this.response = r;
      this.service.postImage(this.response, this.image).subscribe(res => {
        console.log("Respuesta",res);
      });
    });
  }
}
