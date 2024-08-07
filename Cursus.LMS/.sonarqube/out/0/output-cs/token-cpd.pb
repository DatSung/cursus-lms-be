˝	
mD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\ValidationAttribute\Password.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
ValidationAttribute 0
;0 1
public 
class 
Password 
: 
System 
. 
ComponentModel -
.- .
DataAnnotations. =
.= >
ValidationAttribute> Q
{ 
public 

Password 
( 
) 
{ 
ErrorMessage		 
=		 
$str

 
;	

 Ä
} 
public 

override 
bool 
IsValid  
(  !
object! '
value( -
)- .
{ 
if 

( 
value 
is 
string 
password $
)$ %
{ 	
return 
Regex 
. 
IsMatch  
(  !
password! )
,) *
$str+ u
)u v
;v w
} 	
return 
false 
; 
} 
} Ï
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\ValidationAttribute\MaxFileSize.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
ValidationAttribute 0
;0 1
public 
class 
MaxFileSize 
: 
System !
.! "
ComponentModel" 0
.0 1
DataAnnotations1 @
.@ A
ValidationAttributeA T
{ 
private 
readonly 
int 
_maxFileSize %
;% &
public		 

MaxFileSize		 
(		 
int		 
maxFileSize		 &
)		& '
{

 
_maxFileSize 
= 
maxFileSize "
;" #
} 
	protected 
override 
ValidationResult '
?' (
IsValid) 0
(0 1
object1 7
?7 8
value9 >
,> ?
ValidationContext@ Q
validationContextR c
)c d
{ 
var 
file 
= 
value 
as 
	IFormFile %
;% &
if 

( 
file 
!= 
null 
) 
{ 	
if 
( 
file 
. 
Length 
> 
( 
_maxFileSize +
*, -
$num. 2
*3 4
$num5 9
)9 :
): ;
{ 
return 
new 
ValidationResult +
(+ ,
$", .
$str. K
{K L
_maxFileSizeL X
}X Y
$strY ]
"] ^
)^ _
;_ `
} 
} 	
return 
ValidationResult 
.  
Success  '
;' (
} 
} Ø
vD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\ValidationAttribute\AllowedExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
ValidationAttribute 0
;0 1
public 
class 
AllowedExtensions 
:  
System! '
.' (
ComponentModel( 6
.6 7
DataAnnotations7 F
.F G
ValidationAttributeG Z
{ 
private 
readonly 
string 
[ 
] 
_extensions )
;) *
public

 

AllowedExtensions

 
(

 
string

 #
[

# $
]

$ %

extensions

& 0
)

0 1
{ 
_extensions 
= 

extensions  
;  !
} 
	protected 
override 
ValidationResult '
?' (
IsValid) 0
(0 1
object1 7
?7 8
value9 >
,> ?
ValidationContext@ Q
validationContextR c
)c d
{ 
var 
file 
= 
value 
as 
	IFormFile %
;% &
if 

( 
file 
!= 
null 
) 
{ 	
var 
	extension 
= 
Path  
.  !
GetExtension! -
(- .
file. 2
.2 3
FileName3 ;
); <
;< =
if 
( 
! 
_extensions 
. 
Contains %
(% &
	extension& /
./ 0
ToLower0 7
(7 8
)8 9
)9 :
): ;
{ 
return 
new 
ValidationResult +
(+ ,
$str, R
)R S
;S T
} 
} 	
return 
ValidationResult 
.  
Success  '
;' (
} 
} å
jD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticUserRoles.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class 
StaticUserRoles #
{ 
public 

const 
string 
Admin 
= 
$str  '
;' (
public 

const 
string 
Student 
=  !
$str" +
;+ ,
public 

const 
string 

Instructor "
=# $
$str% 1
;1 2
public		 

const		 
string		 
AdminInstructor		 '
=		( )
$str		* =
;		= >
public

 

const

 
string

 
AdminStudent

 $
=

% &
$str

' 7
;

7 8
} ≤
gD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticStatus.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class 
StaticStatus  
{ 
public 

static 
class 
Category  
{ 
public 
const 
int 
New 
= 
$num  
;  !
public 
const 
int 
	Activated "
=# $
$num% &
;& '
public		 
const		 
int		 
Deactivated		 $
=		% &
$num		' (
;		( )
}

 
public 

static 
class 
Order 
{ 
public 
const 
int 
Pending  
=! "
$num# $
;$ %
public 
const 
int 
Paid 
= 
$num  !
;! "
public 
const 
int 
	Confirmed "
=# $
$num% &
;& '
public 
const 
int 
Rejected !
=" #
$num$ %
;% &
public 
const 
int 
PendingRefund &
=' (
$num) *
;* +
public 
const 
int 
ConfirmedRefund (
=) *
$num+ ,
;, -
public 
const 
int 
RejectedRefund '
=( )
$num* +
;+ ,
} 
public 

static 
class 
StudentCourse %
{ 
public 
const 
int 
Pending  
=! "
$num# $
;$ %
public 
const 
int 
Enrolled !
=" #
$num$ %
;% &
public 
const 
int 
Learning !
=" #
$num$ %
;% &
public 
const 
int 
Ended 
=  
$num! "
;" #
public 
const 
int 
Canceled !
=" #
$num$ %
;% &
} 
} Ö
nD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticLoginProvider.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class 
StaticLoginProvider '
{ 
public 

const 
string 
Google 
=  
$str! )
;) *
} ó
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticFirebaseFolders.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class !
StaticFirebaseFolders )
{ 
public 

const 
string 
UserAvatars #
=$ %
$str& 3
;3 4
public 

const 
string 
InstructorDegrees )
=* +
$str, ?
;? @
public 

const 
string 
Course 
=  
$str! )
;) *
} Ò
oD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticFileExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class  
StaticFileExtensions (
{ 
public 

const 
string 
Pdf 
= 
$str /
;/ 0
public 

const 
string 
Jpeg 
= 
$str +
;+ ,
public 

const 
string 
Png 
= 
$str )
;) *
public 

const 
string 
Mp4 
= 
$str )
;) *
public		 

const		 
string		 
Mov		 
=		 
$str		 /
;		/ 0
public

 

const

 
string

 
Doc

 
=

 
$str

 g
;

g h
} ù

eD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticEnum.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class 

StaticEnum 
{ 
public 

enum 
ContentType 
{ 
Json 
, 
MultipartFormData 
, 
}		 
public 

enum 
ApiType 
{ 
GET 
, 
POST 
, 
PUT 
, 
DELETE 
} 
public 

enum 
TransactionType 
{ 
Purchase 
, 
Payout 
, 
Income 
} 
public 

enum 
StripeAccountType !
{ 
express 
, 
standard 
, 
custom 
} 
public!! 

enum!! !
StripeAccountLinkType!! %
{"" 
account_onboarding## 
,## 
account_update$$ 
}%% 
}&& Î
tD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticCourseVersionStatus.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
class %
StaticCourseVersionStatus &
{ 
public 

const 
int 
New 
= 
$num 
; 
public 

const 
int 
	Submitted 
=  
$num! "
;" #
public 

const 
int 
Accepted 
= 
$num  !
;! "
public 

const 
int 
Rejected 
= 
$num  !
;! "
public		 

const		 
int		 
Merged		 
=		 
$num		 
;		  
public

 

const

 
int

 
Removed

 
=

 
$num

  
;

  !
} Ì
mD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticCourseStatus.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
class 
StaticCourseStatus 
{ 
public 

const 
int 
Pending 
= 
$num  
;  !
public 

const 
int 
	Activated 
=  
$num! "
;" #
public 

const 
int 
Deactivated  
=! "
$num# $
;$ %
} π
qD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.Utility\Constants\StaticConnectionString.cs
	namespace 	
Cursus
 
. 
LMS 
. 
Utility 
. 
	Constants &
;& '
public 
static 
class "
StaticConnectionString *
{ 
public 

const 
string #
SQLDB_DefaultConnection /
=0 1
$str2 E
;E F
public 

const 
string !
SQLDB_AzureConnection -
=. /
$str0 H
;H I
public 

const 
string "
REDIS_ConnectionString .
=/ 0
$str1 C
;C D
}		 