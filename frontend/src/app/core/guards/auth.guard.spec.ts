import { TestBed } from '@angular/core/testing';
import { AuthGuard } from './auth.guard';
import { AuthService } from '@core/services/auth.service';
import { Router } from '@angular/router';
import { of } from 'rxjs';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let authServiceMock: any;
  let routerMock: any;

  beforeEach(() => {
    authServiceMock = {
      isLoggedIn$: of(true)
    };

    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };

    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: AuthService, useValue: authServiceMock },
        { provide: Router, useValue: routerMock }
      ]
    });

    guard = TestBed.inject(AuthGuard);
  });

  it('should allow activation when user is logged in', (done) => {
    authServiceMock.isLoggedIn$ = of(true);

    guard.canActivate().subscribe(result => {
      expect(result).toBeTrue();
      done();
    });
  });

  it('should block activation and navigate to login when user is not logged in', (done) => {
    authServiceMock.isLoggedIn$ = of(false);

    guard.canActivate().subscribe(result => {
      expect(result).toBeFalse();
      expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
      done();
    });
  });
});
