import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';

@Injectable()
export class SellersService {
  private headers:HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44301/api/Seller';
  constructor(private http:HttpClient) {
    this.headers = new HttpHeaders({'Content-Type':'application/json;charset=utf-8'})
   }

    /**
    * get all sellersData 
    */
   public get() {
    return this.http.get(this.accessPointUrl,{headers:this.headers}); 
   }

   public add(payload){
     return this.http.post(this.accessPointUrl,payload,{headers:this.headers});
   }

   public remove(payload){
     return this.http.delete(this.accessPointUrl+'/'+payload.id,{headers:this.headers});
   }

   public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }
  }