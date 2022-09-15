import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  constructor(private http:HttpClient) { }
  baseUrl= environment.apiUrl;
  ngOnInit()  {
  }

  get404Error()
  {
    this.http.get(this.baseUrl+'products/42').subscribe(res=>{
        console.log(res);
    },err=>{
      console.log(err);
    });
  }
    get500Error()
  {
    this.http.get(this.baseUrl+'Buggy/servererror').subscribe(res=>{
        console.log(res);
    },err=>{
      console.log(err);
    });
  }
    get400Error()
  {
    this.http.get(this.baseUrl+'Buggy/buggybadrequest').subscribe(res=>{
        console.log(res);
    },err=>{
      console.log(err);
    });
  }

    get400validationError()
  {
    this.http.get(this.baseUrl+'products/fortyrequest').subscribe(res=>{
        console.log(res);
    },err=>{
      console.log(err);
    });
  }

}  