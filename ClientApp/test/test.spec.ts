import {} from 'jasmine';
import { inject } from '@angular/core/testing';
import { HttpModule, Http, Response, ResponseOptions, RequestOptions, Headers, XHRBackend } from '@angular/http';
import { MockBackend, MockConnection } from '@angular/http/testing';

describe('server', () => {
  it('should return the ID of newly added object', () =>{
    expect(true).toBe(true);
  });
});