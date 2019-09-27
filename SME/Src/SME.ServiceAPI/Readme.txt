Features

1. Single Login
2.Two-factor authentication testing
3.Unit testing
4.Performance testing
5.Feature Module configuration runtime
6.

Call Management

1.Call created by customer (created call details pdf email to customer)
2.Call assigned to technician (send call details by email to tech)
3.Call handled and Resolved the problem
4.Verfy work status and close the call by manager(send Invoice mail to Customer)

Status:
1.Open
2.Assign
2.1 Accepted
2.2 NotAccepted
3.0 NotResolved
3.1 Resolved
4.Closed


Managers
  1.Auth
    1.1. Authenticate
	1.2. RefreshToken

  2.Customer
    2.1. Create
	2.2. Update
	2.3. Delete set flag
	2.4. CustomerById(include products)
	2.5. CustomerByName(include products)
	2.6. Customers(not include childs)
	2.7. Customer Login
	2.8. Customer Password Reset

  3. Product
     3.1 Create
	 3.2 Update
	 3.3 Delete
	 3.4 Products
	 3.5 ProductById
	 3.5 ProductByName

  4.User(Role+Claims)
    4.1 RoleCreate
	4.2 UserCreate
	4.3 ClaimCreate
	4.4 ClaimUpdate
	4.5 RoleClaimAssign
	4.6 UserRoleAssign
	4.7 UserClaimAssign
	4.8 UserProfileEdit
	
  5.ServiceCall
    5.1 Create
	5.2 AssignCall
	5.3 ReAssignCall
	5.4 AcceptCall
	5.5 NotAcceptCall
	5.6 NotResolvedCall
	5.7 ResolvedCall
	5.8 ClosedCall
	5.9 CreateFeedback
	5.10 TrackServiceCall(History)


