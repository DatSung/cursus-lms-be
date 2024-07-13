õ5
TD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Program.cs
var

 
builder

 
=

 
WebApplication

 
.

 
CreateBuilder

 *
(

* +
args

+ /
)

/ 0
;

0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. "
AddHttpContextAccessor '
(' (
)( )
;) *
builder 
. 
Services 
. 
AddHttpClient 
( 
)  
;  !
builder 
. 
Services 
. 
AddDbContext 
<  
ApplicationDbContext 2
>2 3
(3 4
options4 ;
=>< >
{ 
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C"
StaticConnectionStringC Y
.Y Z#
SQLDB_DefaultConnectionZ q
)q r
)r s
;s t
} 
) 
; 
builder 
. 
Services 
. 
	Configure 
< .
"DataProtectionTokenProviderOptions =
>= >
(> ?
options? F
=>G I
options 
. 
TokenLifespan 
= 
TimeSpan $
.$ %
FromMinutes% 0
(0 1
$num1 3
)3 4
)4 5
;5 6
builder 
. 
Services 
. 
AddAutoMapper 
( 
typeof %
(% &
AutoMapperProfile& 7
)7 8
)8 9
;9 :
builder## 
.## 
Services## 
.## 
RegisterServices## !
(##! "
)##" #
;### $
builder'' 
.'' 
Services'' 
.'' 
AddFirebaseServices'' $
(''$ %
)''% &
;''& '
builder++ 
.++ 
AddRedisCache++ 
(++ 
)++ 
;++ 
builder// 
.// 
AddHangfireServices// 
(// 
)// 
;// 
builder11 
.11 
Services11 
.11 #
AddEndpointsApiExplorer11 (
(11( )
)11) *
;11* +
builder55 
.55  
AddAppAuthentication55 
(55 
)55 
;55 
builder77 
.77 
Services77 
.77 
AddAuthorization77 !
(77! "
)77" #
;77# $
builder;; 
.;; 
AddSwaggerGen;; 
(;; 
);; 
;;; 
builder>> 
.>> 
Services>> 
.>> 

AddSignalR>> 
(>> 
)>> 
;>> 
builder@@ 
.@@ 
Services@@ 
.@@ 
AddCors@@ 
(@@ 
options@@  
=>@@! #
{AA 
varBB 
originBB 
=BB 
builderBB 
.BB 
ConfigurationBB &
[BB& '
$strBB' E
]BBE F
;BBF G
optionsCC 
.CC 
	AddPolicyCC 
(CC 
$strCC +
,CC+ ,
builderDD 
=>DD 
builderDD 
.EE 
WithOriginsEE 
(EE 
originEE 
)EE  
.FF 
AllowAnyHeaderFF 
(FF 
)FF 
.GG 
AllowAnyMethodGG 
(GG 
)GG 
.HH 
AllowCredentialsHH 
(HH 
)HH 
)HH  
;HH  !
}II 
)II 
;II 
varKK 
appKK 
=KK 	
builderKK
 
.KK 
BuildKK 
(KK 
)KK 
;KK 
ApplyMigrationMM 
(MM 
)MM 
;MM 
ifPP 
(PP 
appPP 
.PP 
EnvironmentPP 
.PP 
IsDevelopmentPP !
(PP! "
)PP" #
)PP# $
{QQ 
appRR 
.RR 

UseSwaggerRR 
(RR 
)RR 
;RR 
appSS 
.SS 
UseSwaggerUISS 
(SS 
)SS 
;SS 
}TT 
appVV 
.VV 
UseCorsVV 
(VV 
$strVV !
)VV! "
;VV" #
appXX 
.XX  
UseHangfireDashboardXX 
(XX 
)XX 
;XX 
appZZ 
.ZZ  
MapHangfireDashboardZZ 
(ZZ 
$strZZ $
)ZZ$ %
;ZZ% &
app\\ 
.\\ 
UseHttpsRedirection\\ 
(\\ 
)\\ 
;\\ 
app^^ 
.^^ 
UseAuthentication^^ 
(^^ 
)^^ 
;^^ 
app`` 
.`` 
UseAuthorization`` 
(`` 
)`` 
;`` 
appbb 
.bb 
MapControllersbb 
(bb 
)bb 
;bb 
appdd 
.dd 
MapHubdd 

<dd
 
NotificationHubdd 
>dd 
(dd 
$strdd 0
)dd0 1
.dd1 2 
RequireAuthorizationdd2 F
(ddF G
)ddG H
;ddH I
appff 
.ff 
Runff 
(ff 
)ff 	
;ff	 

voidhh 
ApplyMigrationhh 
(hh 
)hh 
{ii 
usingjj 	
(jj
 
varjj 
scopejj 
=jj 
appjj 
.jj 
Servicesjj #
.jj# $
CreateScopejj$ /
(jj/ 0
)jj0 1
)jj1 2
{kk 
varll 
contextll 
=ll 
scopell 
.ll 
ServiceProviderll +
.ll+ ,
GetRequiredServicell, >
<ll> ? 
ApplicationDbContextll? S
>llS T
(llT U
)llU V
;llV W
ifnn 

(nn 
contextnn 
.nn 
Databasenn 
.nn  
GetPendingMigrationsnn 1
(nn1 2
)nn2 3
.nn3 4
Anynn4 7
(nn7 8
)nn8 9
)nn9 :
{oo 	
contextpp 
.pp 
Databasepp 
.pp 
Migratepp $
(pp$ %
)pp% &
;pp& '
}qq 	
}rr 
}ss √*
wD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Extentions\WebApplicationBuilderExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 

Extentions #
;# $
public 
static 
class +
WebApplicationBuilderExtensions 3
{ 
public		 

static		 !
WebApplicationBuilder		 ' 
AddAppAuthentication		( <
(		< =
this		= A!
WebApplicationBuilder		B W
builder		X _
)		_ `
{

 
builder 
. 
Services 
. 
AddAuthentication *
(* +
options+ 2
=>3 5
{ 	
options 
. 
DefaultScheme !
=" #
JwtBearerDefaults$ 5
.5 6 
AuthenticationScheme6 J
;J K
options 
. %
DefaultAuthenticateScheme -
=. /
JwtBearerDefaults0 A
.A B 
AuthenticationSchemeB V
;V W
options 
. "
DefaultChallengeScheme *
=+ ,
JwtBearerDefaults- >
.> ? 
AuthenticationScheme? S
;S T
} 	
)	 

.
 
AddJwtBearer 
( 
options 
=>  "
{ 	
options 
. 
	SaveToken 
= 
true  $
;$ %
options 
.  
RequireHttpsMetadata (
=) *
false+ 0
;0 1
options 
. %
TokenValidationParameters -
=. /
new0 3%
TokenValidationParameters4 M
(M N
)N O
{ 
ValidateIssuer 
=  
true! %
,% &
ValidateAudience  
=! "
true# '
,' (
ValidIssuer 
= 
builder %
.% &
Configuration& 3
[3 4
$str4 E
]E F
,F G
ValidAudience 
= 
builder  '
.' (
Configuration( 5
[5 6
$str6 I
]I J
,J K
IssuerSigningKey  
=! "
new# & 
SymmetricSecurityKey' ;
(; <
Encoding< D
.D E
UTF8E I
.I J
GetBytesJ R
(R S
builderS Z
.Z [
Configuration[ h
[h i
$stri u
]u v
)v w
)w x
} 
; 
} 	
)	 

;
 
return 
builder 
; 
} 
public!! 

static!! !
WebApplicationBuilder!! '
AddSwaggerGen!!( 5
(!!5 6
this!!6 :!
WebApplicationBuilder!!; P
builder!!Q X
)!!X Y
{"" 
builder## 
.## 
Services## 
.## 
AddSwaggerGen## &
(##& '
options##' .
=>##/ 1
{$$ 	
options%% 
.%% !
AddSecurityDefinition%% )
(%%) *
name%%* .
:%%. /
$str%%0 8
,%%8 9
securityScheme%%: H
:%%H I
new%%J M!
OpenApiSecurityScheme%%N c
(%%c d
)%%d e
{&& 
Name'' 
='' 
$str'' &
,''& '
In(( 
=(( 
	Microsoft(( 
.(( 
OpenApi(( &
.((& '
Models((' -
.((- .
ParameterLocation((. ?
.((? @
Header((@ F
,((F G
Description)) 
=)) 
$str)) _
,))_ `
Type** 
=** 
	Microsoft**  
.**  !
OpenApi**! (
.**( )
Models**) /
.**/ 0
SecuritySchemeType**0 B
.**B C
ApiKey**C I
,**I J
BearerFormat++ 
=++ 
$str++ $
,++$ %
Scheme,, 
=,, 
$str,, !
}-- 
)-- 
;-- 
options.. 
... "
AddSecurityRequirement.. *
(..* +
new..+ .&
OpenApiSecurityRequirement../ I
(..I J
)..J K
{// 
{00 
new11 !
OpenApiSecurityScheme11 -
(11- .
)11. /
{22 
Name33 
=33 
$str33 '
,33' (
In44 
=44 
ParameterLocation44 .
.44. /
Header44/ 5
,445 6
	Reference55 !
=55" #
new55$ '
OpenApiReference55( 8
(558 9
)559 :
{66 
Id77 
=77  
$str77! )
,77) *
Type88  
=88! "
ReferenceType88# 0
.880 1
SecurityScheme881 ?
}99 
}:: 
,:: 
new;; 
List;; 
<;; 
string;; #
>;;# $
(;;$ %
);;% &
}<< 
}== 
)== 
;== 
}>> 	
)>>	 

;>>
 
return@@ 
builder@@ 
;@@ 
}AA 
}BB Ô$
sD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Extentions\ServiceCollectionExtensions.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 
API		 
.		 

Extentions		 #
;		# $
public 
static 
class '
ServiceCollectionExtensions /
{ 
public 

static 
IServiceCollection $
RegisterServices% 5
(5 6
this6 :
IServiceCollection; M
servicesN V
)V W
{ 
services 
. 
	AddScoped 
< 
IUnitOfWork &
,& '

UnitOfWork( 2
>2 3
(3 4
)4 5
;5 6
services 
. 
	AddScoped 
< 
IBaseService '
,' (
BaseService) 4
>4 5
(5 6
)6 7
;7 8
services 
. 
	AddScoped 
< 
IAuthService '
,' (
AuthService) 4
>4 5
(5 6
)6 7
;7 8
services 
. 
	AddScoped 
< 
IEmailService (
,( )
EmailService* 6
>6 7
(7 8
)8 9
;9 :
services 
. 
	AddScoped 
< 
ITokenService (
,( )
TokenService* 6
>6 7
(7 8
)8 9
;9 :
services 
. 
	AddScoped 
< 
IRedisService (
,( )
RedisService* 6
>6 7
(7 8
)8 9
;9 :
services 
. 
	AddScoped 
< 
ICategoryService +
,+ ,
CategoryService- <
>< =
(= >
)> ?
;? @
services 
. 
	AddScoped 
< 
IInstructorService -
,- .
InstructorService/ @
>@ A
(A B
)B C
;C D
services   
.   
	AddScoped   
<   "
IUserManagerRepository   1
,  1 2!
UserManagerRepository  3 H
>  H I
(  I J
)  J K
;  K L
services"" 
."" 
	AddScoped"" 
<"" 
IClosedXMLService"" ,
,"", -
ClosedXMLService"". >
>""> ?
(""? @
)""@ A
;""A B
services$$ 
.$$ 
	AddScoped$$ 
<$$ 
ICourseService$$ )
,$$) *
CourseService$$+ 8
>$$8 9
($$9 :
)$$: ;
;$$; <
services&& 
.&& 
	AddScoped&& 
<&& !
ICourseVersionService&& 0
,&&0 1 
CourseVersionService&&2 F
>&&F G
(&&G H
)&&H I
;&&I J
services(( 
.(( 
	AddScoped(( 
<(( '
ICourseVersionStatusService(( 6
,((6 7&
CourseVersionStatusService((8 R
>((R S
(((S T
)((T U
;((U V
services** 
.** 
	AddScoped** 
<** (
ICourseSectionVersionService** 7
,**7 8'
CourseSectionVersionService**9 T
>**T U
(**U V
)**V W
;**W X
services,, 
.,, 
	AddScoped,, 
<,, )
ISectionDetailsVersionService,, 8
,,,8 9(
SectionDetailsVersionService,,: V
>,,V W
(,,W X
),,X Y
;,,Y Z
services.. 
... 
	AddScoped.. 
<.. 
ILevelService.. (
,..( )
LevelService..* 6
>..6 7
(..7 8
)..8 9
;..9 :
services00 
.00 
	AddScoped00 
<00 
IEmailSender00 '
,00' (
EmailSender00) 4
>004 5
(005 6
)006 7
;007 8
services33 
.33 
AddIdentity33 
<33 
ApplicationUser33 ,
,33, -
IdentityRole33. :
>33: ;
(33; <
)33< =
.44 $
AddEntityFrameworkStores44 %
<44% & 
ApplicationDbContext44& :
>44: ;
(44; <
)44< =
.55 $
AddDefaultTokenProviders55 %
(55% &
)55& '
;55' (
return77 
services77 
;77 
}88 
}99 ⁄

nD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Extentions\RedisServiceExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 

Extentions #
;# $
public 
static 
class "
RedisServiceExtensions *
{ 
public 

static !
WebApplicationBuilder '
AddRedisCache( 5
(5 6
this6 :!
WebApplicationBuilder; P
builderQ X
)X Y
{		 
string

 
connectionString

 
=

  !
builder 
. 
Configuration !
.! "

GetSection" ,
(, -
$str- 4
)4 5
[5 6"
StaticConnectionString6 L
.L M"
REDIS_ConnectionStringM c
]c d
;d e
builder 
. 
Services 
. 
AddSingleton %
<% &"
IConnectionMultiplexer& <
>< =
(= >!
ConnectionMultiplexer> S
.S T
ConnectT [
([ \
connectionString\ l
)l m
)m n
;n o
return 
builder 
; 
} 
} ö
qD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Extentions\HangfireServiceExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 

Extentions #
;# $
public 
static 
class %
HangfireServiceExtensions -
{ 
public 

static !
WebApplicationBuilder '
AddHangfireServices( ;
(; <
this< @!
WebApplicationBuilderA V
builderW ^
)^ _
{		 
builder

 
.

 
Services

 
.

 
AddHangfire

 $
(

$ %
config

% +
=>

, .
config

/ 5
. %
SetDataCompatibilityLevel &
(& '
CompatibilityLevel' 9
.9 :
Version_180: E
)E F
. /
#UseSimpleAssemblyNameTypeSerializer 0
(0 1
)1 2
. ,
 UseRecommendedSerializerSettings -
(- .
). /
. 
UseSqlServerStorage  
(  !
builder 
. 
Configuration %
.% &
GetConnectionString& 9
(9 :"
StaticConnectionString: P
.P Q#
SQLDB_DefaultConnectionQ h
)h i
)i j
) 	
;	 

builder 
. 
Services 
. 
AddHangfireServer *
(* +
)+ ,
;, -
return 
builder 
; 
} 
} ﬂ
qD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Extentions\FirebaseServiceExtensions.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 

Extentions #
;# $
public		 
static		 
class		 %
FirebaseServiceExtensions		 -
{

 
public 

static 
IServiceCollection $
AddFirebaseServices% 8
(8 9
this9 =
IServiceCollection> P
servicesQ Y
)Y Z
{ 
var 
credentialPath 
= 
Path !
.! "
Combine" )
() *
	Directory* 3
.3 4
GetCurrentDirectory4 G
(G H
)H I
,I J
$str H
)H I
;I J
FirebaseApp 
. 
Create 
( 
new 

AppOptions )
() *
)* +
{ 	

Credential 
= 
GoogleCredential )
.) *
FromFile* 2
(2 3
credentialPath3 A
)A B
} 	
)	 

;
 
services 
. 
AddSingleton 
( 
StorageClient +
.+ ,
Create, 2
(2 3
GoogleCredential3 C
.C D
FromFileD L
(L M
credentialPathM [
)[ \
)\ ]
)] ^
;^ _
services 
. 
	AddScoped 
< 
IFirebaseService +
,+ ,
FirebaseService- <
>< =
(= >
)> ?
;? @
return 
services 
; 
} 
} ˆ
gD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\TestController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
TestController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IFirebaseService )
_firebaseService* :
;: ;
private 
readonly 
IAuthService %
_authService& 2
;2 3
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
private 
readonly 
IHubContext $
<$ %
NotificationHub% 4
>4 5
_hubContext6 A
;A B
public 
TestController 
( 
IFirebaseService .
firebaseService/ >
,> ?
IAuthService@ L
authServiceM X
,X Y
ITokenServiceZ g
tokenServiceh t
,t u
IHubContext 
< 
NotificationHub '
>' (

hubContext) 3
)3 4
{ 	
_firebaseService 
= 
firebaseService .
;. /
_authService 
= 
authService &
;& '
_tokenService 
= 
tokenService (
;( )
_hubContext 
= 

hubContext $
;$ %
} 	
[   	
HttpPost  	 
(   
$str   
)   
]   
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
SendSignalR!!) 4
(!!4 5
string!!5 ;
userId!!< B
)!!B C
{"" 	
await## 
_hubContext## 
.## 
Clients## %
.##% &
User##& *
(##* +
userId##+ 1
)##1 2
.##2 3
	SendAsync##3 <
(##< =
$str##= M
,##M N
$str##O V
)##V W
;##W X
return$$ 
Ok$$ 
($$ 
)$$ 
;$$ 
}%% 	
}&& 
}'' ﬂ1
hD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\LevelController.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 
API		 
.		 
Controllers		 $
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
LevelController  
:! "
ControllerBase# 1
{ 
private 
readonly 
ILevelService &
_levelService' 4
;4 5
public 
LevelController 
( 
ILevelService ,
levelService- 9
)9 :
{ 	
_levelService 
= 
levelService (
;( )
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
	GetLevels5 >
( 	
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[ 
	FromQuery 
] 
int 

pageNumber &
=' (
$num) *
,* +
[ 
	FromQuery 
] 
int 
pageSize $
=% &
$num' (
) 	
{   	
var!! 
responseDto!! 
=!! 
await!! #
_levelService!!$ 1
.!!1 2
	GetLevels!!2 ;
("" 
User## 
,## 
filterOn$$ 
,$$ 
filterQuery%% 
,%% 
sortBy&& 
,&& 
isAscending'' 
,'' 

pageNumber(( 
,(( 
pageSize)) 
)** 
;** 
return++ 

StatusCode++ 
(++ 
responseDto++ )
.++) *

StatusCode++* 4
,++4 5
responseDto++6 A
)++A B
;++B C
},, 	
[.. 	
HttpGet..	 
].. 
[// 	
Route//	 
(// 
$str// 
)//  
]//  !
public00 
async00 
Task00 
<00 
ActionResult00 &
<00& '
ResponseDTO00' 2
>002 3
>003 4
GetLevel005 =
(11 	
[22 
	FromRoute22 
]22 
Guid22 
levelId22 $
)33 	
{44 	
var55 
responseDto55 
=55 
await55 #
_levelService55$ 1
.551 2
GetLevel552 :
(55: ;
User55; ?
,55? @
levelId55A H
)55H I
;55I J
return66 

StatusCode66 
(66 
responseDto66 )
.66) *

StatusCode66* 4
,664 5
responseDto666 A
)66A B
;66B C
}77 	
[99 	
HttpPost99	 
]99 
[:: 	
	Authorize::	 
(:: 
Roles:: 
=:: 
StaticUserRoles:: *
.::* +
Admin::+ 0
)::0 1
]::1 2
public;; 
async;; 
Task;; 
<;; 
ActionResult;; &
<;;& '
ResponseDTO;;' 2
>;;2 3
>;;3 4
CreateLevel;;5 @
(<< 	
[== 
FromBody== 
]== 
CreateLevelDTO== %
createLevelDto==& 4
)>> 	
{?? 	
var@@ 
responseDto@@ 
=@@ 
await@@ #
_levelService@@$ 1
.@@1 2
CreateLevel@@2 =
(@@= >
User@@> B
,@@B C
createLevelDto@@D R
)@@R S
;@@S T
returnAA 

StatusCodeAA 
(AA 
responseDtoAA )
.AA) *

StatusCodeAA* 4
,AA4 5
responseDtoAA6 A
)AAA B
;AAB C
}BB 	
[DD 	
HttpPutDD	 
]DD 
publicEE 
asyncEE 
TaskEE 
<EE 
ActionResultEE &
<EE& '
ResponseDTOEE' 2
>EE2 3
>EE3 4
UpdateLevelEE5 @
(FF 	
[GG 
FromBodyGG 
]GG 
UpdateLevelDTOGG %
updateLevelDtoGG& 4
)HH 	
{II 	
varJJ 
responseDtoJJ 
=JJ 
awaitJJ #
_levelServiceJJ$ 1
.JJ1 2
UpdateLevelJJ2 =
(JJ= >
UserJJ> B
,JJB C
updateLevelDtoJJD R
)JJR S
;JJS T
returnKK 

StatusCodeKK 
(KK 
responseDtoKK )
.KK) *

StatusCodeKK* 4
,KK4 5
responseDtoKK6 A
)KKA B
;KKB C
}LL 	
[NN 	

HttpDeleteNN	 
]NN 
[OO 	
RouteOO	 
(OO 
$strOO 
)OO  
]OO  !
publicPP 
asyncPP 
TaskPP 
<PP 
ActionResultPP &
<PP& '
ResponseDTOPP' 2
>PP2 3
>PP3 4
DeleteLevelPP5 @
(QQ 	
[RR 
	FromRouteRR 
]RR 
GuidRR 
levelIdRR $
)SS 	
{TT 	
varUU 
responseDtoUU 
=UU 
awaitUU #
_levelServiceUU$ 1
.UU1 2
DeleteLevelUU2 =
(UU= >
UserUU> B
,UUB C
levelIdUUD K
)UUK L
;UUL M
returnVV 

StatusCodeVV 
(VV 
responseDtoVV )
.VV) *

StatusCodeVV* 4
,VV4 5
responseDtoVV6 A
)VVA B
;VVB C
}WW 	
}XX 
}YY £ä
mD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\InstructorController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class  
InstructorController %
:& '
ControllerBase( 6
{ 
private 
readonly 
IInstructorService +
_instructorService, >
;> ?
public  
InstructorController #
(# $
IInstructorService$ 6
instructorService7 H
)H I
{ 	
_instructorService 
=  
instructorService! 2
;2 3
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetAllInstructor5 E
( 	
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[ 
	FromQuery 
] 
int 

pageNumber &
=' (
$num) *
,* +
[ 
	FromQuery 
] 
int 
pageSize $
=% &
$num' )
) 	
{ 	
var 
responseDto 
= 
await   
_instructorService   (
.  ( )
GetAll  ) /
(  / 0
User  0 4
,  4 5
filterOn  6 >
,  > ?
filterQuery  @ K
,  K L
sortBy  M S
,  S T
isAscending  U `
,  ` a

pageNumber  b l
,  l m
pageSize  n v
)  v w
;  w x
return!! 

StatusCode!! 
(!! 
responseDto!! )
.!!) *

StatusCode!!* 4
,!!4 5
responseDto!!6 A
)!!A B
;!!B C
}"" 	
[$$ 	
HttpGet$$	 
]$$ 
[%% 	
Route%%	 
(%% 
$str%% $
)%%$ %
]%%% &
public&& 
async&& 
Task&& 
<&& 
ActionResult&& &
<&&& '
ResponseDTO&&' 2
>&&2 3
>&&3 4
GetInstructorById&&5 F
(&&F G
[&&G H
	FromRoute&&H Q
]&&Q R
Guid&&S W
instructorId&&X d
)&&d e
{'' 	
var(( 
responseDto(( 
=(( 
await(( #
_instructorService(($ 6
.((6 7
GetById((7 >
(((> ?
instructorId((? K
)((K L
;((L M
return)) 

StatusCode)) 
()) 
responseDto)) )
.))) *

StatusCode))* 4
,))4 5
responseDto))6 A
)))A B
;))B C
}** 	
[,, 	
HttpGet,,	 
],, 
[-- 	
Route--	 
(-- 
$str-- 2
)--2 3
]--3 4
public.. 
async.. 
Task.. 
<.. 
ActionResult.. &
<..& '
ResponseDTO..' 2
>..2 3
>..3 4)
GetTotalCoursesInstructorById..5 R
(..R S
[..S T
	FromRoute..T ]
]..] ^
Guid.._ c
instructorId..d p
)..p q
{// 	
var00 
responseDto00 
=00 
await00 #
_instructorService00$ 6
.006 7%
GetInstructorTotalCourses007 P
(00P Q
instructorId00Q ]
)00] ^
;00^ _
return11 

StatusCode11 
(11 
responseDto11 )
.11) *

StatusCode11* 4
,114 5
responseDto116 A
)11A B
;11B C
}22 	
[44 	
HttpGet44	 
]44 
[55 	
Route55	 
(55 
$str55 1
)551 2
]552 3
public66 
async66 
Task66 
<66 
ActionResult66 &
<66& '
ResponseDTO66' 2
>662 3
>663 4(
GetTotalRatingInstructorById665 Q
(66Q R
[66R S
	FromRoute66S \
]66\ ]
Guid66^ b
instructorId66c o
)66o p
{77 	
var88 
responseDto88 
=88 
await88 #
_instructorService88$ 6
.886 7$
GetInstructorTotalRating887 O
(88O P
instructorId88P \
)88\ ]
;88] ^
return99 

StatusCode99 
(99 
responseDto99 )
.99) *

StatusCode99* 4
,994 5
responseDto996 A
)99A B
;99B C
}:: 	
[<< 	
HttpGet<<	 
]<< 
[== 	
Route==	 
(== 
$str== 7
)==7 8
]==8 9
public>> 
async>> 
Task>> 
<>> 
ActionResult>> &
<>>& '
ResponseDTO>>' 2
>>>2 3
>>>3 4-
!GetTotalEarnedMoneyInstructorById>>5 V
(>>V W
[>>W X
	FromRoute>>X a
]>>a b
Guid>>c g
instructorId>>h t
)>>t u
{?? 	
var@@ 
responseDto@@ 
=@@ 
await@@ #
_instructorService@@$ 6
.@@6 7$
GetInstructorEarnedMoney@@7 O
(@@O P
instructorId@@P \
)@@\ ]
;@@] ^
returnAA 

StatusCodeAA 
(AA 
responseDtoAA )
.AA) *

StatusCodeAA* 4
,AA4 5
responseDtoAA6 A
)AAA B
;AAB C
}BB 	
[DD 	
HttpGetDD	 
]DD 
[EE 	
RouteEE	 
(EE 
$strEE 7
)EE7 8
]EE8 9
publicFF 
asyncFF 
TaskFF 
<FF 
ActionResultFF &
<FF& '
ResponseDTOFF' 2
>FF2 3
>FF3 4-
!GetTotalPayoutMoneyInstructorByIdFF5 V
(FFV W
[FFW X
	FromRouteFFX a
]FFa b
GuidFFc g
instructorIdFFh t
)FFt u
{GG 	
varHH 
responseDtoHH 
=HH 
awaitHH #
_instructorServiceHH$ 6
.HH6 7$
GetInstructorPayoutMoneyHH7 O
(HHO P
instructorIdHHP \
)HH\ ]
;HH] ^
returnII 

StatusCodeII 
(II 
responseDtoII )
.II) *

StatusCodeII* 4
,II4 5
responseDtoII6 A
)IIA B
;IIB C
}JJ 	
[LL 	
HttpPutLL	 
]LL 
publicMM 
asyncMM 
TaskMM 
<MM 
ActionResultMM &
<MM& '
ResponseDTOMM' 2
>MM2 3
>MM3 4 
UpdateInstructorByIdMM5 I
(MMI J
[MMJ K
FromBodyMMK S
]MMS T
UpdateInstructorDTOMMU h
instructorDtoMMi v
)MMv w
{NN 	
varOO 
responseDtoOO 
=OO 
awaitOO #
_instructorServiceOO$ 6
.OO6 7

UpdateByIdOO7 A
(OOA B
instructorDtoOOB O
)OOO P
;OOP Q
returnPP 

StatusCodePP 
(PP 
responseDtoPP )
.PP) *

StatusCodePP* 4
,PP4 5
responseDtoPP6 A
)PPA B
;PPB C
}QQ 	
[SS 	
HttpPostSS	 
]SS 
[TT 	
RouteTT	 
(TT 
$strTT +
)TT+ ,
]TT, -
publicUU 
asyncUU 
TaskUU 
<UU 
ActionResultUU &
<UU& '
ResponseDTOUU' 2
>UU2 3
>UU3 4
AcceptInstructorUU5 E
(UUE F
[UUF G
	FromRouteUUG P
]UUP Q
GuidUUR V
instructorIdUUW c
)UUc d
{VV 	
varWW 
responseDtoWW 
=WW 
awaitWW #
_instructorServiceWW$ 6
.WW6 7
AcceptInstructorWW7 G
(WWG H
UserWWH L
,WWL M
instructorIdWWN Z
)WWZ [
;WW[ \
returnXX 

StatusCodeXX 
(XX 
responseDtoXX )
.XX) *

StatusCodeXX* 4
,XX4 5
responseDtoXX6 A
)XXA B
;XXB C
}YY 	
[[[ 	
HttpPost[[	 
][[ 
[\\ 	
Route\\	 
(\\ 
$str\\ +
)\\+ ,
]\\, -
public]] 
async]] 
Task]] 
<]] 
ActionResult]] &
<]]& '
ResponseDTO]]' 2
>]]2 3
>]]3 4
RejectInstructor]]5 E
(]]E F
[]]F G
	FromRoute]]G P
]]]P Q
Guid]]R V
instructorId]]W c
)]]c d
{^^ 	
var__ 
responseDto__ 
=__ 
await__ #
_instructorService__$ 6
.__6 7
RejectInstructor__7 G
(__G H
User__H L
,__L M
instructorId__N Z
)__Z [
;__[ \
return`` 

StatusCode`` 
(`` 
responseDto`` )
.``) *

StatusCode``* 4
,``4 5
responseDto``6 A
)``A B
;``B C
}aa 	
[ff 	
HttpGetff	 
]ff 
[gg 	
Routegg	 
(gg 
$strgg ,
)gg, -
]gg- .
publichh 
asynchh 
Taskhh 
<hh 
ActionResulthh &
<hh& '
ResponseDTOhh' 2
>hh2 3
>hh3 4#
GetAllInstructorCommenthh5 L
(ii 	
[jj 
	FromRoutejj 
]jj 
Guidjj 
instructorIdjj )
,jj) *
[kk 
	FromQuerykk 
]kk 
intkk 

pageNumberkk &
=kk' (
$numkk) *
,kk* +
[ll 
	FromQueryll 
]ll 
intll 
pageSizell $
=ll% &
$numll' )
)mm 	
{nn 	
varoo 
responseDtooo 
=oo 
awaitoo #
_instructorServiceoo$ 6
.oo6 7#
GetAllInstructorCommentoo7 N
(ooN O
instructorIdooO [
,oo[ \

pageNumberoo] g
,oog h
pageSizeooi q
)ooq r
;oor s
returnpp 

StatusCodepp 
(pp 
responseDtopp )
.pp) *

StatusCodepp* 4
,pp4 5
responseDtopp6 A
)ppA B
;ppB C
}qq 	
[ss 	
HttpPostss	 
]ss 
[tt 	
Routett	 
(tt 
$strtt 
)tt 
]tt 
publicuu 
asyncuu 
Taskuu 
<uu 
ActionResultuu &
<uu& '
ResponseDTOuu' 2
>uu2 3
>uu3 4#
CreateInstructorCommentuu5 L
(vv 	&
CreateInstructorCommentDTOww &#
createInstructorCommentww' >
)ww> ?
{xx 	
varyy 
responseDtoyy 
=yy 
awaityy #
_instructorServiceyy$ 6
.yy6 7#
CreateInstructorCommentyy7 N
(yyN O
UseryyO S
,yyS T#
createInstructorCommentyyU l
)yyl m
;yym n
returnzz 

StatusCodezz 
(zz 
responseDtozz )
.zz) *

StatusCodezz* 4
,zz4 5
responseDtozz6 A
)zzA B
;zzB C
}{{ 	
[}} 	
HttpPut}}	 
]}} 
[~~ 	
Route~~	 
(~~ 
$str~~ 
)~~ 
]~~ 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4#
UpdateInstructorComment5 L
(
ÄÄ 	(
UpdateInstructorCommentDTO
ÅÅ &%
updateInstructorComment
ÅÅ' >
)
ÅÅ> ?
{
ÇÇ 	
var
ÉÉ 
responseDto
ÉÉ 
=
ÉÉ 
await
ÉÉ # 
_instructorService
ÉÉ$ 6
.
ÉÉ6 7%
UpdateInstructorComment
ÉÉ7 N
(
ÉÉN O
User
ÉÉO S
,
ÉÉS T%
updateInstructorComment
ÉÉU l
)
ÉÉl m
;
ÉÉm n
return
ÑÑ 

StatusCode
ÑÑ 
(
ÑÑ 
responseDto
ÑÑ )
.
ÑÑ) *

StatusCode
ÑÑ* 4
,
ÑÑ4 5
responseDto
ÑÑ6 A
)
ÑÑA B
;
ÑÑB C
}
ÖÖ 	
[
áá 	

HttpDelete
áá	 
]
áá 
[
àà 	
Route
àà	 
(
àà 
$str
àà )
)
àà) *
]
àà* +
public
ââ 
async
ââ 
Task
ââ 
<
ââ 
ActionResult
ââ &
<
ââ& '
ResponseDTO
ââ' 2
>
ââ2 3
>
ââ3 4%
DeleteInstructorComment
ââ5 L
(
ää 	
[
ãã 
	FromRoute
ãã 
]
ãã 
Guid
ãã 
	commentId
ãã &
)
åå 	
{
éé 	
var
èè 
responseDto
èè 
=
èè 
await
èè # 
_instructorService
èè$ 6
.
èè6 7%
DeleteInstructorComment
èè7 N
(
èèN O
	commentId
èèO X
)
èèX Y
;
èèY Z
return
êê 

StatusCode
êê 
(
êê 
responseDto
êê )
.
êê) *

StatusCode
êê* 4
,
êê4 5
responseDto
êê6 A
)
êêA B
;
êêB C
}
ëë 	
[
ìì 	
HttpPost
ìì	 
]
ìì 
[
îî 	
Route
îî	 
(
îî 
$str
îî .
)
îî. /
]
îî/ 0
public
ïï 
async
ïï 
Task
ïï 
<
ïï 
ActionResult
ïï &
<
ïï& '
ResponseDTO
ïï' 2
>
ïï2 3
>
ïï3 4
ExportInstructor
ïï5 E
(
ññ 	
[
óó 
	FromRoute
óó 
]
óó 
int
óó 
month
óó !
,
óó! "
[
òò 
	FromRoute
òò 
]
òò 
int
òò 
year
òò  
)
ôô 	
{
öö 	
var
õõ 
userId
õõ 
=
õõ 
User
õõ 
.
õõ 
Claims
õõ $
.
õõ$ %
FirstOrDefault
õõ% 3
(
õõ3 4
x
õõ4 5
=>
õõ6 8
x
õõ9 :
.
õõ: ;
Type
õõ; ?
==
õõ@ B

ClaimTypes
õõC M
.
õõM N
NameIdentifier
õõN \
)
õõ\ ]
?
õõ] ^
.
õõ^ _
Value
õõ_ d
;
õõd e
BackgroundJob
úú 
.
úú 
Enqueue
úú !
<
úú! " 
IInstructorService
úú" 4
>
úú4 5
(
úú5 6
job
úú6 9
=>
úú: <
job
úú= @
.
úú@ A
ExportInstructors
úúA R
(
úúR S
userId
úúS Y
,
úúY Z
month
úú[ `
,
úú` a
year
úúb f
)
úúf g
)
úúg h
;
úúh i
return
ùù 
Ok
ùù 
(
ùù 
)
ùù 
;
ùù 
}
ûû 	
[
†† 	
HttpGet
††	 
]
†† 
[
°° 	
Route
°°	 
(
°° 
$str
°° $
)
°°$ %
]
°°% &
public
¢¢ 
async
¢¢ 
Task
¢¢ 
<
¢¢ 
ActionResult
¢¢ &
<
¢¢& '"
ClosedXMLResponseDTO
¢¢' ;
>
¢¢; <
>
¢¢< = 
DownloadInstructor
¢¢> P
(
££ 	
[
§§ 
	FromRoute
§§ 
]
§§ 
string
§§ 
fileName
§§ '
)
•• 	
{
¶¶ 	
var
ßß "
closedXmlResponseDto
ßß $
=
ßß% &
await
ßß' , 
_instructorService
ßß- ?
.
ßß? @!
DownloadInstructors
ßß@ S
(
ßßS T
fileName
ßßT \
)
ßß\ ]
;
ßß] ^
var
®® 
stream
®® 
=
®® "
closedXmlResponseDto
®® -
.
®®- .
Stream
®®. 4
;
®®4 5
var
©© 
contentType
©© 
=
©© "
closedXmlResponseDto
©© 2
.
©©2 3
ContentType
©©3 >
;
©©> ?
if
´´ 
(
´´ 
stream
´´ 
is
´´ 
null
´´ 
||
´´ !
contentType
´´" -
is
´´. 0
null
´´1 5
)
´´5 6
{
¨¨ 
return
≠≠ 
NotFound
≠≠ 
(
≠≠  
)
≠≠  !
;
≠≠! "
}
ÆÆ 
return
∞∞ 
File
∞∞ 
(
∞∞ 
stream
∞∞ 
,
∞∞ 
contentType
∞∞  +
,
∞∞+ ,
fileName
∞∞- 5
)
∞∞5 6
;
∞∞6 7
}
±± 	
}
≤≤ 
}≥≥ ±u
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\EmailTemplateController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public 

class #
EmailTemplateController (
:) *
ControllerBase+ 9
{ 
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IEmailService &
_emailService' 4
;4 5
public #
EmailTemplateController &
(& '
IUnitOfWork' 2

unitOfWork3 =
,= >
IEmailService? L
emailServiceM Y
)Y Z
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
_emailService 
= 
emailService (
;( )
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4 
GetAllEmailTemplates5 I
(I J
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[   
	FromQuery   
]   
int   

pageNumber   &
=  ' (
$num  ) *
,  * +
[!! 
	FromQuery!! 
]!! 
int!! 
pageSize!! $
=!!% &
$num!!' )
)!!) *
{"" 	
var$$ 
responseDto$$ 
=$$ 
await%% 
_emailService%% #
.%%# $
GetAll%%$ *
(%%* +
User%%+ /
,%%/ 0
filterOn%%1 9
,%%9 :
filterQuery%%; F
,%%F G
sortBy%%H N
,%%N O
isAscending%%P [
,%%[ \

pageNumber%%] g
,%%g h
pageSize%%i q
)%%q r
;%%r s
return&& 

StatusCode&& 
(&& 
responseDto&& )
.&&) *

StatusCode&&* 4
,&&4 5
responseDto&&6 A
)&&A B
;&&B C
}'' 	
[.. 	
HttpGet..	 
(.. 
$str.. 
).. 
].. 
public// 
async// 
Task// 
<// 
ActionResult// &
<//& '
ResponseDTO//' 2
>//2 3
>//3 4 
GetEmailTemplateById//5 I
(//I J
Guid//J N
id//O Q
)//Q R
{00 	
var11 
emailTemplate11 
=11 
await11  %
_unitOfWork11& 1
.111 2#
EmailTemplateRepository112 I
.11I J
GetAsync11J R
(11R S
x11S T
=>11U W
x11X Y
.11Y Z
Id11Z \
==11] _
id11` b
)11b c
;11c d
if22 
(22 
emailTemplate22 
==22  
null22! %
)22% &
{33 
return44 
NotFound44 
(44  
new44  #
ResponseDTO44$ /
{55 
	IsSuccess66 
=66 
false66  %
,66% &
Message77 
=77 
$str77 <
}88 
)88 
;88 
}99 
return;; 
Ok;; 
(;; 
new;; 
ResponseDTO;; %
{<< 
Result== 
=== 
emailTemplate== &
,==& '
	IsSuccess>> 
=>> 
true>>  
,>>  !
Message?? 
=?? 
$str?? ;
}@@ 
)@@ 
;@@ 
}AA 	
[II 	
HttpPutII	 
(II 
$strII 
)II 
]II 
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
ActionResultJJ &
<JJ& '
ResponseDTOJJ' 2
>JJ2 3
>JJ3 4
UpdateEmailTemplateJJ5 H
(JJH I
GuidJJI M
idJJN P
,JJP Q"
UpdateEmailTemplateDTOKK ""
updateEmailTemplateDTOKK# 9
)KK9 :
{LL 	
varMM 
emailTemplateMM 
=MM 
awaitMM  %
_unitOfWorkMM& 1
.MM1 2#
EmailTemplateRepositoryMM2 I
.MMI J
GetAsyncMMJ R
(MMR S
xMMS T
=>MMU W
xMMX Y
.MMY Z
IdMMZ \
==MM] _
idMM` b
)MMb c
;MMc d
ifOO 
(OO 
emailTemplateOO 
==OO  
nullOO! %
)OO% &
{PP 
returnQQ 
NotFoundQQ 
(QQ  
newQQ  #
ResponseDTOQQ$ /
{RR 
	IsSuccessSS 
=SS 
falseSS  %
,SS% &
MessageTT 
=TT 
$strTT <
}UU 
)UU 
;UU 
}VV 
emailTemplateYY 
.YY 
TemplateNameYY &
=YY' ("
updateEmailTemplateDTOYY) ?
.YY? @
TemplateNameYY@ L
;YYL M
emailTemplateZZ 
.ZZ 

SenderNameZZ $
=ZZ% &"
updateEmailTemplateDTOZZ' =
.ZZ= >

SenderNameZZ> H
;ZZH I
emailTemplate[[ 
.[[ 
SenderEmail[[ %
=[[& '"
updateEmailTemplateDTO[[( >
.[[> ?
SenderEmail[[? J
;[[J K
emailTemplate\\ 
.\\ 
Category\\ "
=\\# $"
updateEmailTemplateDTO\\% ;
.\\; <
Category\\< D
;\\D E
emailTemplate]] 
.]] 
SubjectLine]] %
=]]& '"
updateEmailTemplateDTO]]( >
.]]> ?
SubjectLine]]? J
;]]J K
emailTemplate^^ 
.^^ 
PreHeaderText^^ '
=^^( )"
updateEmailTemplateDTO^^* @
.^^@ A
PreHeaderText^^A N
;^^N O
emailTemplate__ 
.__ 
PersonalizationTags__ -
=__. /"
updateEmailTemplateDTO__0 F
.__F G
PersonalizationTags__G Z
;__Z [
emailTemplate`` 
.`` 
BodyContent`` %
=``& '"
updateEmailTemplateDTO``( >
.``> ?
BodyContent``? J
;``J K
emailTemplateaa 
.aa 
FooterContentaa '
=aa( )"
updateEmailTemplateDTOaa* @
.aa@ A
FooterContentaaA N
;aaN O
emailTemplatebb 
.bb 
CallToActionbb &
=bb' ("
updateEmailTemplateDTObb) ?
.bb? @
CallToActionbb@ L
;bbL M
emailTemplatecc 
.cc 
Languagecc "
=cc# $"
updateEmailTemplateDTOcc% ;
.cc; <
Languagecc< D
;ccD E
emailTemplatedd 
.dd 
RecipientTypedd '
=dd( )"
updateEmailTemplateDTOdd* @
.dd@ A
RecipientTypeddA N
;ddN O
_unitOfWorkff 
.ff #
EmailTemplateRepositoryff /
.ff/ 0
Updateff0 6
(ff6 7
emailTemplateff7 D
)ffD E
;ffE F
awaitgg 
_unitOfWorkgg 
.gg 
	SaveAsyncgg '
(gg' (
)gg( )
;gg) *
returnii 
Okii 
(ii 
newii 
ResponseDTOii %
{jj 
Resultkk 
=kk 
emailTemplatekk &
,kk& '
	IsSuccessll 
=ll 
truell  
,ll  !
Messagemm 
=mm 
$strmm >
}nn 
)nn 
;nn 
}oo 	
[vv 	

HttpDeletevv	 
(vv 
$strvv 
)vv  
]vv  !
publicww 
ActionResultww 
<ww 
ResponseDTOww '
>ww' (
DeleteEmailTemplateww) <
(ww< =
Guidww= A
idwwB D
)wwD E
{xx 	
returnyy 

BadRequestyy 
(yy 
newyy !
ResponseDTOyy" -
{zz 
	IsSuccess{{ 
={{ 
false{{ !
,{{! "
Message|| 
=|| 
$str|| C
}}} 
)}} 
;}} 
}~~ 	
[
ÖÖ 	
HttpPost
ÖÖ	 
]
ÖÖ 
public
ÜÜ 
ActionResult
ÜÜ 
<
ÜÜ 
ResponseDTO
ÜÜ '
>
ÜÜ' (!
CreateEmailTemplate
ÜÜ) <
(
ÜÜ< =$
CreateEmailTemplateDTO
ÜÜ= S$
createEmailTemplateDTO
ÜÜT j
)
ÜÜj k
{
áá 	
return
àà 

BadRequest
àà 
(
àà 
new
àà !
ResponseDTO
àà" -
{
ââ 
	IsSuccess
ää 
=
ää 
false
ää !
,
ää! "
Message
ãã 
=
ãã 
$str
ãã B
}
åå 
)
åå 
;
åå 
}
çç 	
[
èè 	
HttpGet
èè	 
(
èè 
$str
èè 4
)
èè4 5
]
èè5 6
public
êê 
async
êê 
Task
êê 
<
êê 
ActionResult
êê &
<
êê& '
ResponseDTO
êê' 2
>
êê2 3
>
êê3 4-
SendEmailForAdminAboutNewCourse
êê5 T
(
êêT U
string
êêU [
toMail
êê\ b
)
êêb c
{
ëë 	
var
íí 
response
íí 
=
íí 
new
íí 
ResponseDTO
íí *
(
íí* +
)
íí+ ,
;
íí, -
try
îî 
{
ïï 
bool
ññ 
result
ññ 
=
ññ 
await
ññ #
_emailService
ññ$ 1
.
ññ1 2-
SendEmailForAdminAboutNewCourse
ññ2 Q
(
ññQ R
toMail
ññR X
)
ññX Y
;
ññY Z
response
óó 
.
óó 
	IsSuccess
óó "
=
óó# $
result
óó% +
;
óó+ ,
response
òò 
.
òò 
Message
òò  
=
òò! "
result
òò# )
?
òò* +
$str
òò, F
:
òòG H
$str
òòI `
;
òò` a
}
ôô 
catch
öö 
(
öö 
	Exception
öö 
ex
öö 
)
öö  
{
õõ 
response
úú 
.
úú 
	IsSuccess
úú "
=
úú# $
false
úú% *
;
úú* +
response
ùù 
.
ùù 
Message
ùù  
=
ùù! "
ex
ùù# %
.
ùù% &
Message
ùù& -
;
ùù- .
}
ûû 
return
†† 
Ok
†† 
(
†† 
response
†† 
)
†† 
;
††  
}
°° 	
[
§§ 	
HttpGet
§§	 
(
§§ 
$str
§§ B
)
§§B C
]
§§C D
public
•• 
async
•• 
Task
•• 
<
•• 
ActionResult
•• &
<
••& '
ResponseDTO
••' 2
>
••2 3
>
••3 49
+SendApproveEmailForInstructorAboutNewCourse
••5 `
(
••` a
string
••a g
toMail
••h n
)
••n o
{
¶¶ 	
var
ßß 
response
ßß 
=
ßß 
new
ßß 
ResponseDTO
ßß *
(
ßß* +
)
ßß+ ,
;
ßß, -
try
©© 
{
™™ 
bool
´´ 
result
´´ 
=
´´ 
await
´´ #
_emailService
´´$ 1
.
´´1 29
+SendApproveEmailForInstructorAboutNewCourse
´´2 ]
(
´´] ^
toMail
´´^ d
)
´´d e
;
´´e f
response
¨¨ 
.
¨¨ 
	IsSuccess
¨¨ "
=
¨¨# $
result
¨¨% +
;
¨¨+ ,
response
≠≠ 
.
≠≠ 
Message
≠≠  
=
≠≠! "
result
≠≠# )
?
≠≠* +
$str
≠≠, F
:
≠≠G H
$str
≠≠I `
;
≠≠` a
}
ÆÆ 
catch
ØØ 
(
ØØ 
	Exception
ØØ 
ex
ØØ 
)
ØØ  
{
∞∞ 
response
±± 
.
±± 
	IsSuccess
±± "
=
±±# $
false
±±% *
;
±±* +
response
≤≤ 
.
≤≤ 
Message
≤≤  
=
≤≤! "
ex
≤≤# %
.
≤≤% &
Message
≤≤& -
;
≤≤- .
}
≥≥ 
return
µµ 
Ok
µµ 
(
µµ 
response
µµ 
)
µµ 
;
µµ  
}
∂∂ 	
[
∏∏ 	
HttpGet
∏∏	 
(
∏∏ 
$str
∏∏ B
)
∏∏B C
]
∏∏C D
public
ππ 
async
ππ 
Task
ππ 
<
ππ 
ActionResult
ππ &
<
ππ& '
ResponseDTO
ππ' 2
>
ππ2 3
>
ππ3 48
*SendRejectEmailForInstructorAboutNewCourse
ππ5 _
(
ππ_ `
string
ππ` f
toMail
ππg m
)
ππm n
{
∫∫ 	
var
ªª 
response
ªª 
=
ªª 
new
ªª 
ResponseDTO
ªª *
(
ªª* +
)
ªª+ ,
;
ªª, -
try
ΩΩ 
{
ææ 
bool
øø 
result
øø 
=
øø 
await
øø #
_emailService
øø$ 1
.
øø1 28
*SendRejectEmailForInstructorAboutNewCourse
øø2 \
(
øø\ ]
toMail
øø] c
)
øøc d
;
øød e
response
¿¿ 
.
¿¿ 
	IsSuccess
¿¿ "
=
¿¿# $
result
¿¿% +
;
¿¿+ ,
response
¡¡ 
.
¡¡ 
Message
¡¡  
=
¡¡! "
result
¡¡# )
?
¡¡* +
$str
¡¡, F
:
¡¡G H
$str
¡¡I `
;
¡¡` a
}
¬¬ 
catch
√√ 
(
√√ 
	Exception
√√ 
ex
√√ 
)
√√  
{
ƒƒ 
response
≈≈ 
.
≈≈ 
	IsSuccess
≈≈ "
=
≈≈# $
false
≈≈% *
;
≈≈* +
response
∆∆ 
.
∆∆ 
Message
∆∆  
=
∆∆! "
ex
∆∆# %
.
∆∆% &
Message
∆∆& -
;
∆∆- .
}
«« 
return
…… 
Ok
…… 
(
…… 
response
…… 
)
…… 
;
……  
}
   	
}
ÀÀ 
}ÃÃ œØ
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CourseVersionController.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 
API		 
.		 
Controllers		 $
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class #
CourseVersionController (
:) *
ControllerBase+ 9
{ 
private 
readonly !
ICourseVersionService .!
_courseVersionService/ D
;D E
private 
readonly (
ICourseSectionVersionService 5(
_courseSectionVersionService6 R
;R S
private 
readonly )
ISectionDetailsVersionService 6)
_sectionDetailsVersionService7 T
;T U
public #
CourseVersionController &
(& '!
ICourseVersionService' < 
courseVersionService= Q
,Q R(
ICourseSectionVersionService ('
courseSectionVersionService) D
,D E)
ISectionDetailsVersionService )(
sectionDetailsVersionService* F
)F G
{ 	!
_courseVersionService !
=" # 
courseVersionService$ 8
;8 9(
_courseSectionVersionService (
=) *'
courseSectionVersionService+ F
;F G)
_sectionDetailsVersionService )
=* +(
sectionDetailsVersionService, H
;H I
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetCourseVersions5 F
(   	
[!! 
	FromQuery!! 
]!! 
Guid!! 
?!! 
courseId!! &
,!!& '
["" 
	FromQuery"" 
]"" 
string"" 
?"" 
filterOn""  (
,""( )
[## 
	FromQuery## 
]## 
string## 
?## 
filterQuery##  +
,##+ ,
[$$ 
	FromQuery$$ 
]$$ 
string$$ 
?$$ 
sortBy$$  &
,$$& '
[%% 
	FromQuery%% 
]%% 
bool%% 
?%% 
isAscending%% )
,%%) *
[&& 
	FromQuery&& 
]&& 
int&& 

pageNumber&& &
=&&' (
$num&&) *
,&&* +
['' 
	FromQuery'' 
]'' 
int'' 
pageSize'' $
=''% &
$num''' (
)(( 	
{)) 	
var** 
responseDto** 
=** 
await** #!
_courseVersionService**$ 9
.**9 :
GetCourseVersions**: K
(++ 
User,, 
,,, 
courseId-- 
,-- 
filterOn.. 
,.. 
filterQuery// 
,// 
sortBy00 
,00 
isAscending11 
,11 

pageNumber22 
,22 
pageSize33 
)44 
;44 
return66 

StatusCode66 
(66 
responseDto66 )
.66) *

StatusCode66* 4
,664 5
responseDto666 A
)66A B
;66B C
}77 	
[99 	
HttpGet99	 
]99 
[:: 	
Route::	 
(:: 
$str::  
)::  !
]::! "
public;; 
async;; 
Task;; 
<;; 
ActionResult;; &
<;;& '
ResponseDTO;;' 2
>;;2 3
>;;3 4
GetCourseVersion;;5 E
(;;E F
[;;F G
	FromRoute;;G P
];;P Q
Guid;;R V
courseId;;W _
);;_ `
{<< 	
var== 
responseDto== 
=== 
await== #!
_courseVersionService==$ 9
.==9 :
GetCourseVersion==: J
(==J K
User==K O
,==O P
courseId==Q Y
)==Y Z
;==Z [
return>> 

StatusCode>> 
(>> 
responseDto>> )
.>>) *

StatusCode>>* 4
,>>4 5
responseDto>>6 A
)>>A B
;>>B C
}?? 	
[AA 	
HttpPostAA	 
]AA 
[BB 	
RouteBB	 
(BB 
$strBB &
)BB& '
]BB' (
[CC 	
	AuthorizeCC	 
(CC 
RolesCC 
=CC 
StaticUserRolesCC *
.CC* +

InstructorCC+ 5
)CC5 6
]CC6 7
publicDD 
asyncDD 
TaskDD 
<DD 
ActionResultDD &
<DD& '
ResponseDTODD' 2
>DD2 3
>DD3 4"
CreateCourseAndVersionDD5 K
(EE 	(
CreateNewCourseAndVersionDTOFF ((
createNewCourseAndVersionDtoFF) E
)GG 	
{HH 	
varII 
responseDtoII 
=II 
awaitII #!
_courseVersionServiceII$ 9
.II9 :"
CreateCourseAndVersionII: P
(IIP Q
UserIIQ U
,IIU V(
createNewCourseAndVersionDtoIIW s
)IIs t
;IIt u
returnJJ 

StatusCodeJJ 
(JJ 
responseDtoJJ )
.JJ) *

StatusCodeJJ* 4
,JJ4 5
responseDtoJJ6 A
)JJA B
;JJB C
}KK 	
[MM 	
HttpPostMM	 
]MM 
[NN 	
RouteNN	 
(NN 
$strNN %
)NN% &
]NN& '
[OO 	
	AuthorizeOO	 
(OO 
RolesOO 
=OO 
StaticUserRolesOO *
.OO* +

InstructorOO+ 5
)OO5 6
]OO6 7
publicPP 
asyncPP 
TaskPP 
<PP 
ActionResultPP &
<PP& '
ResponseDTOPP' 2
>PP2 3
>PP3 4
CloneCourseVersionPP5 G
(QQ 	
[RR 
FromBodyRR 
]RR !
CloneCourseVersionDTORR ,!
cloneCourseVersionDtoRR- B
)SS 	
{TT 	
varUU 
responseDtoUU 
=UU 
awaitUU #!
_courseVersionServiceUU$ 9
.UU9 :
CloneCourseVersionUU: L
(UUL M
UserUUM Q
,UUQ R!
cloneCourseVersionDtoUUS h
)UUh i
;UUi j
returnVV 

StatusCodeVV 
(VV 
responseDtoVV )
.VV) *

StatusCodeVV* 4
,VV4 5
responseDtoVV6 A
)VVA B
;VVB C
}WW 	
[YY 	
HttpPutYY	 
]YY 
[ZZ 	
RouteZZ	 
(ZZ 
$strZZ $
)ZZ$ %
]ZZ% &
public[[ 
async[[ 
Task[[ 
<[[ 
ActionResult[[ &
<[[& '
ResponseDTO[[' 2
>[[2 3
>[[3 4
EditCourseVersion[[5 F
(\\ 	
[]] 
FromBody]] 
]]]  
EditCourseVersionDTO]] + 
editCourseVersionDto]], @
)]]@ A
{^^ 	
var__ 
responseDto__ 
=__ 
await__ #!
_courseVersionService__$ 9
.__9 :
EditCourseVersion__: K
(__K L
User__L P
,__P Q 
editCourseVersionDto__R f
)__f g
;__g h
return`` 

StatusCode`` 
(`` 
responseDto`` )
.``) *

StatusCode``* 4
,``4 5
responseDto``6 A
)``A B
;``B C
}aa 	
[cc 	

HttpDeletecc	 
]cc 
[dd 	
Routedd	 
(dd 
$strdd 6
)dd6 7
]dd7 8
publicee 
asyncee 
Taskee 
<ee 
ActionResultee &
<ee& '
ResponseDTOee' 2
>ee2 3
>ee3 4
RemoveCourseVersionee5 H
(eeH I
[eeI J
	FromRouteeeJ S
]eeS T
GuideeU Y
courseIdeeZ b
)eeb c
{ff 	
vargg 
responseDtogg 
=gg 
awaitgg #!
_courseVersionServicegg$ 9
.gg9 :
RemoveCourseVersiongg: M
(ggM N
UserggN R
,ggR S
courseIdggT \
)gg\ ]
;gg] ^
returnhh 

StatusCodehh 
(hh 
responseDtohh )
.hh) *

StatusCodehh* 4
,hh4 5
responseDtohh6 A
)hhA B
;hhB C
}ii 	
[kk 	
HttpPostkk	 
]kk 
[ll 	
Routell	 
(ll 
$strll 6
)ll6 7
]ll7 8
publicmm 
asyncmm 
Taskmm 
<mm 
ActionResultmm &
<mm& '
ResponseDTOmm' 2
>mm2 3
>mm3 4
AcceptCourseVersionmm5 H
(mmH I
[mmI J
	FromRoutemmJ S
]mmS T
GuidmmU Y
courseIdmmZ b
)mmb c
{nn 	
varoo 
responseDtooo 
=oo 
awaitoo #!
_courseVersionServiceoo$ 9
.oo9 :
AcceptCourseVersionoo: M
(ooM N
UserooN R
,ooR S
courseIdooT \
)oo\ ]
;oo] ^
returnpp 

StatusCodepp 
(pp 
responseDtopp )
.pp) *

StatusCodepp* 4
,pp4 5
responseDtopp6 A
)ppA B
;ppB C
}qq 	
[ss 	
HttpPostss	 
]ss 
[tt 	
Routett	 
(tt 
$strtt 6
)tt6 7
]tt7 8
publicuu 
asyncuu 
Taskuu 
<uu 
ActionResultuu &
<uu& '
ResponseDTOuu' 2
>uu2 3
>uu3 4
RejectCourseVersionuu5 H
(uuH I
[uuI J
	FromRouteuuJ S
]uuS T
GuiduuU Y
courseIduuZ b
)uub c
{vv 	
varww 
responseDtoww 
=ww 
awaitww #!
_courseVersionServiceww$ 9
.ww9 :
RejectCourseVersionww: M
(wwM N
UserwwN R
,wwR S
courseIdwwT \
)ww\ ]
;ww] ^
returnxx 

StatusCodexx 
(xx 
responseDtoxx )
.xx) *

StatusCodexx* 4
,xx4 5
responseDtoxx6 A
)xxA B
;xxB C
}yy 	
[{{ 	
HttpPost{{	 
]{{ 
[|| 	
Route||	 
(|| 
$str|| 6
)||6 7
]||7 8
public}} 
async}} 
Task}} 
<}} 
ActionResult}} &
<}}& '
ResponseDTO}}' 2
>}}2 3
>}}3 4
SubmitCourseVersion}}5 H
(}}H I
[}}I J
	FromRoute}}J S
]}}S T
Guid}}U Y
courseId}}Z b
)}}b c
{~~ 	
var 
responseDto 
= 
await #!
_courseVersionService$ 9
.9 :
SubmitCourseVersion: M
(M N
UserN R
,R S
courseIdT \
)\ ]
;] ^
return
ÄÄ 

StatusCode
ÄÄ 
(
ÄÄ 
responseDto
ÄÄ )
.
ÄÄ) *

StatusCode
ÄÄ* 4
,
ÄÄ4 5
responseDto
ÄÄ6 A
)
ÄÄA B
;
ÄÄB C
}
ÅÅ 	
[
ÉÉ 	
HttpPost
ÉÉ	 
]
ÉÉ 
[
ÑÑ 	
Route
ÑÑ	 
(
ÑÑ 
$str
ÑÑ 5
)
ÑÑ5 6
]
ÑÑ6 7
public
ÖÖ 
async
ÖÖ 
Task
ÖÖ 
<
ÖÖ 
ActionResult
ÖÖ &
<
ÖÖ& '
ResponseDTO
ÖÖ' 2
>
ÖÖ2 3
>
ÖÖ3 4 
MergeCourseVersion
ÖÖ5 G
(
ÖÖG H
[
ÖÖH I
	FromRoute
ÖÖI R
]
ÖÖR S
Guid
ÖÖT X
courseId
ÖÖY a
)
ÖÖa b
{
ÜÜ 	
var
áá 
responseDto
áá 
=
áá 
await
áá ##
_courseVersionService
áá$ 9
.
áá9 : 
MergeCourseVersion
áá: L
(
ááL M
User
ááM Q
,
ááQ R
courseId
ááS [
)
áá[ \
;
áá\ ]
return
àà 

StatusCode
àà 
(
àà 
responseDto
àà )
.
àà) *

StatusCode
àà* 4
,
àà4 5
responseDto
àà6 A
)
ààA B
;
ààB C
}
ââ 	
[
ãã 	
HttpPost
ãã	 
]
ãã 
[
åå 	
Route
åå	 
(
åå 
$str
åå 9
)
åå9 :
]
åå: ;
public
çç 
async
çç 
Task
çç 
<
çç 
ActionResult
çç &
<
çç& '
ResponseDTO
çç' 2
>
çç2 3
>
çç3 4+
UploadCourseVersionBackground
çç5 R
(
éé 	
[
èè 
	FromRoute
èè 
]
èè 
Guid
èè 
courseVersionId
èè ,
,
èè, -.
 UploadCourseVersionBackgroundImg
êê ,.
 uploadCourseVersionBackgroundImg
êê- M
)
ëë 	
{
íí 	
var
ìì 
responseDto
ìì 
=
ìì 
await
îî #
_courseVersionService
îî +
.
îî+ ,.
 UploadCourseVersionBackgroundImg
îî, L
(
ïï 
User
ññ 
,
ññ 
courseVersionId
óó #
,
óó# $.
 uploadCourseVersionBackgroundImg
òò 4
)
ôô 
;
ôô 
return
öö 

StatusCode
öö 
(
öö 
responseDto
öö )
.
öö) *

StatusCode
öö* 4
,
öö4 5
responseDto
öö6 A
)
ööA B
;
ööB C
}
õõ 	
[
ùù 	
HttpGet
ùù	 
]
ùù 
[
ûû 	
Route
ûû	 
(
ûû 
$str
ûû :
)
ûû: ;
]
ûû; <
public
üü 
async
üü 
Task
üü 
<
üü 
ActionResult
üü &
>
üü& ',
DisplayCourseVersionBackground
üü( F
(
†† 	
[
°° 
	FromRoute
°° 
]
°° 
Guid
°° 
courseVersionId
°° ,
)
¢¢ 	
{
££ 	
var
§§ 
responseDto
§§ 
=
§§ 
await
§§ ##
_courseVersionService
§§$ 9
.
§§9 :/
!DisplayCourseVersionBackgroundImg
§§: [
(
§§[ \
User
§§\ `
,
§§` a
courseVersionId
§§b q
)
§§q r
;
§§r s
if
•• 
(
•• 
responseDto
•• 
is
•• 
null
•• #
)
••# $
{
¶¶ 
return
ßß 
null
ßß 
;
ßß 
}
®® 
return
©© 
File
©© 
(
©© 
responseDto
©© #
,
©©# $
$str
©©% 0
)
©©0 1
;
©©1 2
}
™™ 	
[
±± 	
HttpGet
±±	 
]
±± 
[
≤≤ 	
Route
≤≤	 
(
≤≤ 
$str
≤≤ 
)
≤≤ 
]
≤≤ 
public
≥≥ 
async
≥≥ 
Task
≥≥ 
<
≥≥ 
ActionResult
≥≥ &
<
≥≥& '
ResponseDTO
≥≥' 2
>
≥≥2 3
>
≥≥3 4'
GetCourseVersionsComments
≥≥5 N
(
¥¥ 	
[
µµ 
	FromQuery
µµ 
]
µµ 
[
µµ 
Required
µµ !
]
µµ! "
Guid
µµ# '
courseVersionId
µµ( 7
,
µµ7 8
[
∂∂ 
	FromQuery
∂∂ 
]
∂∂ 
string
∂∂ 
?
∂∂ 
filterOn
∂∂  (
,
∂∂( )
[
∑∑ 
	FromQuery
∑∑ 
]
∑∑ 
string
∑∑ 
?
∑∑ 
filterQuery
∑∑  +
,
∑∑+ ,
[
∏∏ 
	FromQuery
∏∏ 
]
∏∏ 
string
∏∏ 
?
∏∏ 
sortBy
∏∏  &
,
∏∏& '
[
ππ 
	FromQuery
ππ 
]
ππ 
int
ππ 

pageNumber
ππ &
=
ππ' (
$num
ππ) *
,
ππ* +
[
∫∫ 
	FromQuery
∫∫ 
]
∫∫ 
int
∫∫ 
pageSize
∫∫ $
=
∫∫% &
$num
∫∫' )
)
ªª 	
{
ºº 	
var
ΩΩ 
responseDto
ΩΩ 
=
ΩΩ 
await
ΩΩ ##
_courseVersionService
ΩΩ$ 9
.
ΩΩ9 :'
GetCourseVersionsComments
ΩΩ: S
(
ææ 
User
øø 
,
øø 
courseVersionId
¿¿ 
,
¿¿  
filterOn
¡¡ 
,
¡¡ 
filterQuery
¬¬ 
,
¬¬ 
sortBy
√√ 
,
√√ 

pageNumber
ƒƒ 
,
ƒƒ 
pageSize
≈≈ 
)
∆∆ 
;
∆∆ 
return
»» 

StatusCode
»» 
(
»» 
responseDto
»» )
.
»») *

StatusCode
»»* 4
,
»»4 5
responseDto
»»6 A
)
»»A B
;
»»B C
}
…… 	
[
ÀÀ 	
HttpGet
ÀÀ	 
]
ÀÀ 
[
ÃÃ 	
Route
ÃÃ	 
(
ÃÃ 
$str
ÃÃ )
)
ÃÃ) *
]
ÃÃ* +
public
ÕÕ 
async
ÕÕ 
Task
ÕÕ 
<
ÕÕ 
ActionResult
ÕÕ &
<
ÕÕ& '
ResponseDTO
ÕÕ' 2
>
ÕÕ2 3
>
ÕÕ3 4%
GetCourseVersionComment
ÕÕ5 L
(
ÕÕL M
[
ÕÕM N
	FromRoute
ÕÕN W
]
ÕÕW X
Guid
ÕÕY ]
	commentId
ÕÕ^ g
)
ÕÕg h
{
ŒŒ 	
var
œœ 
responseDto
œœ 
=
œœ 
await
œœ ##
_courseVersionService
œœ$ 9
.
œœ9 :%
GetCourseVersionComment
œœ: Q
(
œœQ R
User
œœR V
,
œœV W
	commentId
œœX a
)
œœa b
;
œœb c
return
–– 

StatusCode
–– 
(
–– 
responseDto
–– )
.
––) *

StatusCode
––* 4
,
––4 5
responseDto
––6 A
)
––A B
;
––B C
}
—— 	
[
”” 	
HttpPost
””	 
]
”” 
[
‘‘ 	
Route
‘‘	 
(
‘‘ 
$str
‘‘ 
)
‘‘ 
]
‘‘ 
public
’’ 
async
’’ 
Task
’’ 
<
’’ 
ActionResult
’’ &
<
’’& '
ResponseDTO
’’' 2
>
’’2 3
>
’’3 4(
CreateCourseVersionComment
’’5 O
(
÷÷ 	,
CreateCourseVersionCommentsDTO
◊◊ *,
createCourseVersionCommentsDto
◊◊+ I
)
ÿÿ 	
{
ŸŸ 	
var
⁄⁄ 
responseDto
⁄⁄ 
=
⁄⁄ 
await
€€ #
_courseVersionService
€€ +
.
€€+ ,(
CreateCourseVersionComment
€€, F
(
€€F G
User
€€G K
,
€€K L,
createCourseVersionCommentsDto
€€M k
)
€€k l
;
€€l m
return
‹‹ 

StatusCode
‹‹ 
(
‹‹ 
responseDto
‹‹ )
.
‹‹) *

StatusCode
‹‹* 4
,
‹‹4 5
responseDto
‹‹6 A
)
‹‹A B
;
‹‹B C
}
›› 	
[
ﬂﬂ 	
HttpPut
ﬂﬂ	 
]
ﬂﬂ 
[
‡‡ 	
Route
‡‡	 
(
‡‡ 
$str
‡‡ 
)
‡‡ 
]
‡‡ 
public
·· 
async
·· 
Task
·· 
<
·· 
ActionResult
·· &
<
··& '
ResponseDTO
··' 2
>
··2 3
>
··3 4&
EditCourseVersionComment
··5 M
(
‚‚ 	*
EditCourseVersionCommentsDTO
„„ (*
editCourseVersionCommentsDto
„„) E
)
‰‰ 	
{
ÂÂ 	
var
ÊÊ 
responseDto
ÊÊ 
=
ÊÊ 
await
ÊÊ ##
_courseVersionService
ÊÊ$ 9
.
ÊÊ9 :&
EditCourseVersionComment
ÊÊ: R
(
ÊÊR S
User
ÊÊS W
,
ÊÊW X*
editCourseVersionCommentsDto
ÊÊY u
)
ÊÊu v
;
ÊÊv w
return
ÁÁ 

StatusCode
ÁÁ 
(
ÁÁ 
responseDto
ÁÁ )
.
ÁÁ) *

StatusCode
ÁÁ* 4
,
ÁÁ4 5
responseDto
ÁÁ6 A
)
ÁÁA B
;
ÁÁB C
}
ËË 	
[
ÍÍ 	

HttpDelete
ÍÍ	 
]
ÍÍ 
[
ÎÎ 	
Route
ÎÎ	 
(
ÎÎ 
$str
ÎÎ )
)
ÎÎ) *
]
ÎÎ* +
public
ÏÏ 
async
ÏÏ 
Task
ÏÏ 
<
ÏÏ 
ActionResult
ÏÏ &
<
ÏÏ& '
ResponseDTO
ÏÏ' 2
>
ÏÏ2 3
>
ÏÏ3 4(
RemoveCourseVersionComment
ÏÏ5 O
(
ÏÏO P
[
ÌÌ 
	FromRoute
ÌÌ 
]
ÌÌ 
Guid
ÌÌ 
	commentId
ÌÌ &
)
ÌÌ& '
{
ÓÓ 	
var
ÔÔ 
responseDto
ÔÔ 
=
ÔÔ 
await
 #
_courseVersionService
 +
.
+ ,(
RemoveCourseVersionComment
, F
(
F G
User
G K
,
K L
	commentId
M V
)
V W
;
W X
return
ÒÒ 

StatusCode
ÒÒ 
(
ÒÒ 
responseDto
ÒÒ )
.
ÒÒ) *

StatusCode
ÒÒ* 4
,
ÒÒ4 5
responseDto
ÒÒ6 A
)
ÒÒA B
;
ÒÒB C
}
ÚÚ 	
[
˘˘ 	
HttpGet
˘˘	 
]
˘˘ 
[
˙˙ 	
Route
˙˙	 
(
˙˙ 
$str
˙˙ 
)
˙˙ 
]
˙˙ 
public
˚˚ 
async
˚˚ 
Task
˚˚ 
<
˚˚ 
ActionResult
˚˚ &
<
˚˚& '
ResponseDTO
˚˚' 2
>
˚˚2 3
>
˚˚3 4
GetCourseSections
˚˚5 F
(
¸¸ 	
[
˝˝ 
	FromQuery
˝˝ 
]
˝˝ 
[
˝˝ 
Required
˝˝ !
]
˝˝! "
Guid
˝˝# '
?
˝˝' (
courseVersionId
˝˝) 8
,
˝˝8 9
[
˛˛ 
	FromQuery
˛˛ 
]
˛˛ 
string
˛˛ 
?
˛˛ 
filterOn
˛˛  (
,
˛˛( )
[
ˇˇ 
	FromQuery
ˇˇ 
]
ˇˇ 
string
ˇˇ 
?
ˇˇ 
filterQuery
ˇˇ  +
,
ˇˇ+ ,
[
ÄÄ 
	FromQuery
ÄÄ 
]
ÄÄ 
string
ÄÄ 
?
ÄÄ 
sortBy
ÄÄ  &
,
ÄÄ& '
[
ÅÅ 
	FromQuery
ÅÅ 
]
ÅÅ 
bool
ÅÅ 
?
ÅÅ 
isAscending
ÅÅ )
,
ÅÅ) *
[
ÇÇ 
	FromQuery
ÇÇ 
]
ÇÇ 
int
ÇÇ 

pageNumber
ÇÇ &
=
ÇÇ' (
$num
ÇÇ) *
,
ÇÇ* +
[
ÉÉ 
	FromQuery
ÉÉ 
]
ÉÉ 
int
ÉÉ 
pageSize
ÉÉ $
=
ÉÉ% &
$num
ÉÉ' (
)
ÑÑ 	
{
ÖÖ 	
var
ÜÜ 
responseDto
ÜÜ 
=
ÜÜ 
await
ÜÜ #*
_courseSectionVersionService
ÜÜ$ @
.
ÜÜ@ A
GetCourseSections
ÜÜA R
(
áá 
User
àà 
,
àà 
courseVersionId
ââ 
,
ââ  
filterOn
ää 
,
ää 
filterQuery
ãã 
,
ãã 
sortBy
åå 
,
åå 

pageNumber
çç 
,
çç 
pageSize
éé 
)
èè 
;
èè 
return
ëë 

StatusCode
ëë 
(
ëë 
responseDto
ëë )
.
ëë) *

StatusCode
ëë* 4
,
ëë4 5
responseDto
ëë6 A
)
ëëA B
;
ëëB C
}
íí 	
[
ïï 	
HttpGet
ïï	 
]
ïï 
[
ññ 	
Route
ññ	 
(
ññ 
$str
ññ )
)
ññ) *
]
ññ* +
public
óó 
async
óó 
Task
óó 
<
óó 
ActionResult
óó &
<
óó& '
ResponseDTO
óó' 2
>
óó2 3
>
óó3 4
GetCourseSection
óó5 E
(
óóE F
[
óóF G
	FromRoute
óóG P
]
óóP Q
Guid
óóR V
	sectionId
óóW `
)
óó` a
{
òò 	
var
ôô 
responseDto
ôô 
=
ôô 
await
ôô #*
_courseSectionVersionService
ôô$ @
.
ôô@ A
GetCourseSection
ôôA Q
(
ôôQ R
User
ôôR V
,
ôôV W
	sectionId
ôôX a
)
ôôa b
;
ôôb c
return
öö 

StatusCode
öö 
(
öö 
responseDto
öö )
.
öö) *

StatusCode
öö* 4
,
öö4 5
responseDto
öö6 A
)
ööA B
;
ööB C
}
õõ 	
[
ùù 	
HttpPost
ùù	 
]
ùù 
[
ûû 	
Route
ûû	 
(
ûû 
$str
ûû .
)
ûû. /
]
ûû/ 0
[
üü 	
	Authorize
üü	 
(
üü 
Roles
üü 
=
üü 
StaticUserRoles
üü *
.
üü* +

Instructor
üü+ 5
)
üü5 6
]
üü6 7
public
†† 
async
†† 
Task
†† 
<
†† 
ActionResult
†† &
<
††& '
ResponseDTO
††' 2
>
††2 3
>
††3 4!
CreateCourseSection
††5 H
(
°° 	+
CreateCourseSectionVersionDTO
¢¢ )+
createCourseSectionVersionDto
¢¢* G
)
££ 	
{
§§ 	
var
•• 
responseDto
•• 
=
•• 
await
¶¶ *
_courseSectionVersionService
¶¶ 2
.
¶¶2 3!
CreateCourseSection
¶¶3 F
(
¶¶F G
User
¶¶G K
,
¶¶K L+
createCourseSectionVersionDto
¶¶M j
)
¶¶j k
;
¶¶k l
return
ßß 

StatusCode
ßß 
(
ßß 
responseDto
ßß )
.
ßß) *

StatusCode
ßß* 4
,
ßß4 5
responseDto
ßß6 A
)
ßßA B
;
ßßB C
}
®® 	
[
™™ 	
HttpPut
™™	 
]
™™ 
[
´´ 	
Route
´´	 
(
´´ 
$str
´´ ,
)
´´, -
]
´´- .
public
¨¨ 
async
¨¨ 
Task
¨¨ 
<
¨¨ 
ActionResult
¨¨ &
<
¨¨& '
ResponseDTO
¨¨' 2
>
¨¨2 3
>
¨¨3 4
EditCourseSection
¨¨5 F
(
≠≠ 	)
EditCourseSectionVersionDTO
ÆÆ '+
createCourseSectionVersionDto
ÆÆ( E
)
ØØ 	
{
∞∞ 	
var
±± 
responseDto
±± 
=
±± 
await
±± #*
_courseSectionVersionService
±±$ @
.
±±@ A
EditCourseSection
±±A R
(
±±R S
User
±±S W
,
±±W X+
createCourseSectionVersionDto
±±Y v
)
±±v w
;
±±w x
return
≤≤ 

StatusCode
≤≤ 
(
≤≤ 
responseDto
≤≤ )
.
≤≤) *

StatusCode
≤≤* 4
,
≤≤4 5
responseDto
≤≤6 A
)
≤≤A B
;
≤≤B C
}
≥≥ 	
[
µµ 	

HttpDelete
µµ	 
]
µµ 
[
∂∂ 	
Route
∂∂	 
(
∂∂ 
$str
∂∂ $
)
∂∂$ %
]
∂∂% &
public
∑∑ 
async
∑∑ 
Task
∑∑ 
<
∑∑ 
ActionResult
∑∑ &
<
∑∑& '
ResponseDTO
∑∑' 2
>
∑∑2 3
>
∑∑3 4!
DeleteCourseSection
∑∑5 H
(
∏∏ 	
[
ππ 
	FromRoute
ππ 
]
ππ 
Guid
ππ 
	sectionId
ππ &
)
∫∫ 	
{
ªª 	
var
ºº 
responseDto
ºº 
=
ºº 
await
ΩΩ *
_courseSectionVersionService
ΩΩ 2
.
ΩΩ2 3!
RemoveCourseSection
ΩΩ3 F
(
ΩΩF G
User
ΩΩG K
,
ΩΩK L
	sectionId
ΩΩM V
)
ΩΩV W
;
ΩΩW X
return
ææ 

StatusCode
ææ 
(
ææ 
responseDto
ææ )
.
ææ) *

StatusCode
ææ* 4
,
ææ4 5
responseDto
ææ6 A
)
ææA B
;
ææB C
}
øø 	
[
≈≈ 	
HttpGet
≈≈	 
]
≈≈ 
[
∆∆ 	
Route
∆∆	 
(
∆∆ 
$str
∆∆  
)
∆∆  !
]
∆∆! "
public
«« 
async
«« 
Task
«« 
<
«« 
ActionResult
«« &
<
««& '
ResponseDTO
««' 2
>
««2 3
>
««3 4(
GetSectionsDetailsVersions
««5 O
(
»» 	
[
…… 
	FromQuery
…… 
]
…… 
Guid
…… 
?
…… 
courseSectionId
…… -
,
……- .
[
   
	FromQuery
   
]
   
string
   
?
   
filterOn
    (
,
  ( )
[
ÀÀ 
	FromQuery
ÀÀ 
]
ÀÀ 
string
ÀÀ 
?
ÀÀ 
filterQuery
ÀÀ  +
,
ÀÀ+ ,
[
ÃÃ 
	FromQuery
ÃÃ 
]
ÃÃ 
string
ÃÃ 
?
ÃÃ 
sortBy
ÃÃ  &
,
ÃÃ& '
[
ÕÕ 
	FromQuery
ÕÕ 
]
ÕÕ 
bool
ÕÕ 
?
ÕÕ 
isAscending
ÕÕ )
,
ÕÕ) *
[
ŒŒ 
	FromQuery
ŒŒ 
]
ŒŒ 
int
ŒŒ 

pageNumber
ŒŒ &
=
ŒŒ' (
$num
ŒŒ) *
,
ŒŒ* +
[
œœ 
	FromQuery
œœ 
]
œœ 
int
œœ 
pageSize
œœ $
=
œœ% &
$num
œœ' (
)
–– 	
{
—— 	
var
““ 
responseDto
““ 
=
““ 
await
““ #+
_sectionDetailsVersionService
““$ A
.
““A B(
GetSectionsDetailsVersions
““B \
(
”” 
User
‘‘ 
,
‘‘ 
courseSectionId
’’ 
,
’’  
filterOn
÷÷ 
,
÷÷ 
filterQuery
◊◊ 
,
◊◊ 
sortBy
ÿÿ 
,
ÿÿ 
isAscending
ŸŸ 
,
ŸŸ 

pageNumber
⁄⁄ 
,
⁄⁄ 
pageSize
€€ 
)
‹‹ 
;
‹‹ 
return
›› 

StatusCode
›› 
(
›› 
responseDto
›› )
.
››) *

StatusCode
››* 4
,
››4 5
responseDto
››6 A
)
››A B
;
››B C
}
ﬁﬁ 	
[
‡‡ 	
HttpGet
‡‡	 
]
‡‡ 
[
·· 	
Route
··	 
(
·· 
$str
·· 1
)
··1 2
]
··2 3
public
‚‚ 
async
‚‚ 
Task
‚‚ 
<
‚‚ 
ActionResult
‚‚ &
<
‚‚& '
ResponseDTO
‚‚' 2
>
‚‚2 3
>
‚‚3 4'
GetSectionsDetailsVersion
‚‚5 N
(
‚‚N O
[
‚‚O P
	FromRoute
‚‚P Y
]
‚‚Y Z
Guid
‚‚[ _
	detailsId
‚‚` i
)
‚‚i j
{
„„ 	
var
‰‰ 
responseDto
‰‰ 
=
‰‰ 
await
‰‰ #+
_sectionDetailsVersionService
‰‰$ A
.
‰‰A B&
GetSectionDetailsVersion
‰‰B Z
(
‰‰Z [
User
‰‰[ _
,
‰‰_ `
	detailsId
‰‰a j
)
‰‰j k
;
‰‰k l
return
ÂÂ 

StatusCode
ÂÂ 
(
ÂÂ 
responseDto
ÂÂ )
.
ÂÂ) *

StatusCode
ÂÂ* 4
,
ÂÂ4 5
responseDto
ÂÂ6 A
)
ÂÂA B
;
ÂÂB C
}
ÊÊ 	
[
ËË 	
HttpPost
ËË	 
]
ËË 
[
ÈÈ 	
Route
ÈÈ	 
(
ÈÈ 
$str
ÈÈ  
)
ÈÈ  !
]
ÈÈ! "
[
ÍÍ 	
	Authorize
ÍÍ	 
(
ÍÍ 
Roles
ÍÍ 
=
ÍÍ 
StaticUserRoles
ÍÍ *
.
ÍÍ* +

Instructor
ÍÍ+ 5
)
ÍÍ5 6
]
ÍÍ6 7
public
ÎÎ 
async
ÎÎ 
Task
ÎÎ 
<
ÎÎ 
ActionResult
ÎÎ &
<
ÎÎ& '
ResponseDTO
ÎÎ' 2
>
ÎÎ2 3
>
ÎÎ3 4)
CreateSectionDetailsVersion
ÎÎ5 P
(
ÎÎP Q
[
ÏÏ 
FromBody
ÏÏ 
]
ÏÏ ,
CreateSectionDetailsVersionDTO
ÏÏ 5,
createSectionDetailsVersionDto
ÏÏ6 T
)
ÏÏT U
{
ÌÌ 	
var
ÓÓ 
responseDto
ÓÓ 
=
ÓÓ 
await
ÔÔ +
_sectionDetailsVersionService
ÔÔ 3
.
ÔÔ3 4)
CreateSectionDetailsVersion
ÔÔ4 O
(
ÔÔO P
User
ÔÔP T
,
ÔÔT U,
createSectionDetailsVersionDto
ÔÔV t
)
ÔÔt u
;
ÔÔu v
return
 

StatusCode
 
(
 
responseDto
 )
.
) *

StatusCode
* 4
,
4 5
responseDto
6 A
)
A B
;
B C
}
ÒÒ 	
[
ÛÛ 	
HttpPut
ÛÛ	 
]
ÛÛ 
[
ÙÙ 	
Route
ÙÙ	 
(
ÙÙ 
$str
ÙÙ  
)
ÙÙ  !
]
ÙÙ! "
public
ıı 
async
ıı 
Task
ıı 
<
ıı 
ActionResult
ıı &
<
ıı& '
ResponseDTO
ıı' 2
>
ıı2 3
>
ıı3 4'
EditSectionDetailsVersion
ıı5 N
(
ııN O
[
ˆˆ 
FromBody
ˆˆ 
]
ˆˆ *
EditSectionDetailsVersionDTO
ˆˆ 3*
editSectionDetailsVersionDto
ˆˆ4 P
)
ˆˆP Q
{
˜˜ 	
var
¯¯ 
responseDto
¯¯ 
=
¯¯ 
await
˘˘ +
_sectionDetailsVersionService
˘˘ 3
.
˘˘3 4'
EditSectionDetailsVersion
˘˘4 M
(
˘˘M N
User
˘˘N R
,
˘˘R S*
editSectionDetailsVersionDto
˘˘T p
)
˘˘p q
;
˘˘q r
return
˙˙ 

StatusCode
˙˙ 
(
˙˙ 
responseDto
˙˙ )
.
˙˙) *

StatusCode
˙˙* 4
,
˙˙4 5
responseDto
˙˙6 A
)
˙˙A B
;
˙˙B C
}
˚˚ 	
[
˝˝ 	

HttpDelete
˝˝	 
]
˝˝ 
[
˛˛ 	
Route
˛˛	 
(
˛˛ 
$str
˛˛ 1
)
˛˛1 2
]
˛˛2 3
public
ˇˇ 
async
ˇˇ 
Task
ˇˇ 
<
ˇˇ 
ActionResult
ˇˇ &
<
ˇˇ& '
ResponseDTO
ˇˇ' 2
>
ˇˇ2 3
>
ˇˇ3 4)
RemoveSectionDetailsVersion
ˇˇ5 P
(
ˇˇP Q
[
ˇˇQ R
	FromRoute
ˇˇR [
]
ˇˇ[ \
Guid
ˇˇ] a
	detailsId
ˇˇb k
)
ˇˇk l
{
ÄÄ 	
var
ÅÅ 
responseDto
ÅÅ 
=
ÅÅ 
await
ÇÇ +
_sectionDetailsVersionService
ÇÇ 3
.
ÇÇ3 4)
RemoveSectionDetailsVersion
ÇÇ4 O
(
ÇÇO P
User
ÇÇP T
,
ÇÇT U
	detailsId
ÇÇV _
)
ÇÇ_ `
;
ÇÇ` a
return
ÉÉ 

StatusCode
ÉÉ 
(
ÉÉ 
responseDto
ÉÉ )
.
ÉÉ) *

StatusCode
ÉÉ* 4
,
ÉÉ4 5
responseDto
ÉÉ6 A
)
ÉÉA B
;
ÉÉB C
}
ÑÑ 	
[
ÜÜ 	
HttpPost
ÜÜ	 
]
ÜÜ 
[
áá 	
Route
áá	 
(
áá 
$str
áá 9
)
áá9 :
]
áá: ;
public
àà 
async
àà 
Task
àà 
<
àà 
ActionResult
àà &
<
àà& '
ResponseDTO
àà' 2
>
àà2 3
>
àà3 40
"UploadSectionDetailsVersionContent
àà5 W
(
ââ 	
[
ää 
	FromRoute
ää 
]
ää 
Guid
ää 
	detailsId
ää &
,
ää& '3
%UploadSectionDetailsVersionContentDTO
ãã 13
%uploadSectionDetailsVersionContentDto
ãã2 W
)
åå 	
{
çç 	
var
éé 
responseDto
éé 
=
éé 
await
èè +
_sectionDetailsVersionService
èè 3
.
èè3 40
"UploadSectionDetailsVersionContent
èè4 V
(
êê 
User
ëë 
,
ëë 
	detailsId
íí 
,
íí 3
%uploadSectionDetailsVersionContentDto
ìì 9
)
îî 
;
îî 
return
ïï 

StatusCode
ïï 
(
ïï 
responseDto
ïï )
.
ïï) *

StatusCode
ïï* 4
,
ïï4 5
responseDto
ïï6 A
)
ïïA B
;
ïïB C
}
ññ 	
[
òò 	
HttpGet
òò	 
]
òò 
[
ôô 	
Route
ôô	 
(
ôô 
$str
ôô )
)
ôô) *
]
ôô* +
public
öö 
async
öö 
Task
öö 
<
öö 
IActionResult
öö '
>
öö' (1
#DisplaySectionDetailsVersionContent
öö) L
(
õõ 	
[
úú 
	FromQuery
úú 
]
úú 
Guid
úú %
sectionDetailsVersionId
úú 4
,
úú4 5
[
ùù 
	FromQuery
ùù 
]
ùù 
string
ùù 
type
ùù #
)
ûû 	
{
üü 	
var
††  
contentResponseDto
†† "
=
††# $
await
°° +
_sectionDetailsVersionService
°° 3
.
°°3 41
#DisplaySectionDetailsVersionContent
°°4 W
(
¢¢ 
User
££ 
,
££ %
sectionDetailsVersionId
§§ +
,
§§+ ,
type
•• 
)
¶¶ 
;
¶¶ 
if
®® 
(
®®  
contentResponseDto
®® "
.
®®" #
Stream
®®# )
is
®®* ,
null
®®- 1
)
®®1 2
{
©© 
return
™™ 
NotFound
™™ 
(
™™  
$str
™™  7
)
™™7 8
;
™™8 9
}
´´ 
if
≠≠ 
(
≠≠  
contentResponseDto
≠≠ "
.
≠≠" #
ContentType
≠≠# .
==
≠≠/ 1"
StaticFileExtensions
≠≠2 F
.
≠≠F G
Mov
≠≠G J
||
≠≠K M 
contentResponseDto
ÆÆ "
.
ÆÆ" #
ContentType
ÆÆ# .
==
ÆÆ/ 1"
StaticFileExtensions
ÆÆ2 F
.
ÆÆF G
Mp4
ÆÆG J
)
ÆÆJ K
{
ØØ 
return
∞∞ 
File
∞∞ 
(
∞∞  
contentResponseDto
∞∞ .
.
∞∞. /
Stream
∞∞/ 5
,
∞∞5 6 
contentResponseDto
∞∞7 I
.
∞∞I J
ContentType
∞∞J U
)
∞∞U V
;
∞∞V W
}
±± 
return
≥≥ 
File
≥≥ 
(
≥≥  
contentResponseDto
≥≥ *
.
≥≥* +
Stream
≥≥+ 1
,
≥≥1 2 
contentResponseDto
≥≥3 E
.
≥≥E F
ContentType
≥≥F Q
,
≥≥Q R 
contentResponseDto
≥≥S e
.
≥≥e f
FileName
≥≥f n
)
≥≥n o
;
≥≥o p
}
¥¥ 	
}
∑∑ 
}∏∏ ö.
iD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CourseController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
CourseController

 !
:

" #
ControllerBase

$ 2
{ 
private 
ICourseService 
_courseService -
;- .
public 
CourseController 
(  
ICourseService  .
courseService/ <
)< =
{ 	
_courseService 
= 
courseService *
;* +
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4

GetCourses5 ?
( 	
[ 
	FromQuery 
] 
Guid 
? 
instructorId *
,* +
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[ 
	FromQuery 
] 
double 
? 
	fromPrice  )
,) *
[ 
	FromQuery 
] 
double 
? 
toPrice  '
,' (
[ 
	FromQuery 
] 
int 

pageNumber &
=' (
$num) *
,* +
[ 
	FromQuery 
] 
int 
pageSize $
=% &
$num' (
) 	
{   	
var!! 
responseDto!! 
=!! 
await!! #
_courseService!!$ 2
.!!2 3

GetCourses!!3 =
("" 
User## 
,## 
instructorId$$ 
,$$ 
filterOn%% 
,%% 
filterQuery&& 
,&& 
	fromPrice'' 
,'' 
toPrice(( 
,(( 
sortBy)) 
,)) 
isAscending** 
,** 

pageNumber++ 
,++ 
pageSize,, 
)-- 
;-- 
return.. 

StatusCode.. 
(.. 
responseDto.. )
...) *

StatusCode..* 4
,..4 5
responseDto..6 A
)..A B
;..B C
}// 	
[11 	
HttpGet11	 
]11 
[22 	
Route22	 
(22 
$str22  
)22  !
]22! "
public33 
async33 
Task33 
<33 
ActionResult33 &
<33& '
ResponseDTO33' 2
>332 3
>333 4
	GetCourse335 >
(33> ?
[33? @
	FromRoute33@ I
]33I J
Guid33K O
courseId33P X
)33X Y
{44 	
var55 
responseDto55 
=55 
await55 #
_courseService55$ 2
.552 3
	GetCourse553 <
(55< =
User55= A
,55A B
courseId55C K
)55K L
;55L M
return66 

StatusCode66 
(66 
responseDto66 )
.66) *

StatusCode66* 4
,664 5
responseDto666 A
)66A B
;66B C
}77 	
[99 	
HttpPost99	 
]99 
[:: 	
Route::	 
(:: 
$str:: 0
)::0 1
]::1 2
public;; 
async;; 
Task;; 
<;; 
ActionResult;; &
<;;& '
ResponseDTO;;' 2
>;;2 3
>;;3 4
ActivateCourse;;5 C
(;;C D
[;;D E
	FromRoute;;E N
];;N O
Guid;;P T
courseId;;U ]
);;] ^
{<< 	
var== 
responseDto== 
=== 
await== #
_courseService==$ 2
.==2 3
ActivateCourse==3 A
(==A B
User==B F
,==F G
courseId==H P
)==P Q
;==Q R
return>> 

StatusCode>> 
(>> 
responseDto>> )
.>>) *

StatusCode>>* 4
,>>4 5
responseDto>>6 A
)>>A B
;>>B C
}?? 	
[AA 	
HttpPostAA	 
]AA 
[BB 	
RouteBB	 
(BB 
$strBB 2
)BB2 3
]BB3 4
publicCC 
asyncCC 
TaskCC 
<CC 
ActionResultCC &
<CC& '
ResponseDTOCC' 2
>CC2 3
>CC3 4
DeactivateCourseCC5 E
(CCE F
[CCF G
	FromRouteCCG P
]CCP Q
GuidCCR V
courseIdCCW _
)CC_ `
{DD 	
varEE 
responseDtoEE 
=EE 
awaitEE #
_courseServiceEE$ 2
.EE2 3
DeactivateCourseEE3 C
(EEC D
UserEED H
,EEH I
courseIdEEJ R
)EER S
;EES T
returnFF 

StatusCodeFF 
(FF 
responseDtoFF )
.FF) *

StatusCodeFF* 4
,FF4 5
responseDtoFF6 A
)FFA B
;FFB C
}GG 	
}HH 
}II ¶L
kD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CategoryController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
CategoryController

 #
:

$ %
ControllerBase

& 4
{ 
private 
readonly 
ICategoryService )
_categoryService* :
;: ;
public 
CategoryController !
(! "
ICategoryService" 2
categoryService3 B
)B C
{ 	
_categoryService 
= 
categoryService .
;. /
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetAll5 ;
( 	
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[ 
	FromQuery 
] 
int 

pageNumber &
=' (
$num) *
,* +
[ 
	FromQuery 
] 
int 
pageSize $
=% &
$num' )
) 	
{ 	
var 
responseDto 
= 
await 
_categoryService &
.& '
GetAll' -
(- .
User. 2
,2 3
filterOn4 <
,< =
filterQuery> I
,I J
sortByK Q
,Q R
isAscendingS ^
,^ _

pageNumber` j
,j k
pageSizel t
)t u
;u v
return   

StatusCode   
(   
responseDto   )
.  ) *

StatusCode  * 4
,  4 5
responseDto  6 A
)  A B
;  B C
}!! 	
[## 	
HttpGet##	 
]## 
[$$ 	
Route$$	 
($$ 
$str$$ 
)$$ 
]$$ 
public%% 
async%% 
Task%% 
<%% 
ActionResult%% &
<%%& '
ResponseDTO%%' 2
>%%2 3
>%%3 4
Search%%5 ;
(&& 	
['' 
	FromQuery'' 
]'' 
string'' 
?'' 
filterOn''  (
,''( )
[(( 
	FromQuery(( 
](( 
string(( 
?(( 
filterQuery((  +
,((+ ,
[)) 
	FromQuery)) 
])) 
string)) 
?)) 
sortBy))  &
,))& '
[** 
	FromQuery** 
]** 
bool** 
?** 
isAscending** )
,**) *
[++ 
	FromQuery++ 
]++ 
int++ 

pageNumber++ &
=++' (
$num++) *
,++* +
[,, 
	FromQuery,, 
],, 
int,, 
pageSize,, $
=,,% &
$num,,' (
)-- 	
{.. 	
var// 
responseDto// 
=// 
await// #
_categoryService//$ 4
.//4 5
Search//5 ;
(//; <
User//< @
,//@ A
filterOn//B J
,//J K
filterQuery//L W
,//W X
sortBy//Y _
,//_ `
isAscending//a l
,//l m

pageNumber00 
,00 
pageSize00 $
)00$ %
;00% &
return11 

StatusCode11 
(11 
responseDto11 )
.11) *

StatusCode11* 4
,114 5
responseDto116 A
)11A B
;11B C
}22 	
[44 	
HttpGet44	 
]44 
[55 	
Route55	 
(55 
$str55 +
)55+ ,
]55, -
public66 
async66 
Task66 
<66 
ActionResult66 &
<66& '
ResponseDTO66' 2
>662 3
>663 4
GetSubCategory665 C
(66C D
[66D E
	FromRoute66E N
]66N O
Guid66P T
id66U W
)66W X
{77 	
var88 
responseDto88 
=88 
await88 #
_categoryService88$ 4
.884 5
GetSubCategory885 C
(88C D
id88D F
)88F G
;88G H
return99 

StatusCode99 
(99 
responseDto99 )
.99) *

StatusCode99* 4
,994 5
responseDto996 A
)99A B
;99B C
}:: 	
[<< 	
HttpGet<<	 
]<< 
[== 	
Route==	 
(== 
$str== .
)==. /
]==/ 0
public>> 
async>> 
Task>> 
<>> 
ActionResult>> &
<>>& '
ResponseDTO>>' 2
>>>2 3
>>>3 4
GetParentCategory>>5 F
(>>F G
[>>G H
	FromRoute>>H Q
]>>Q R
Guid>>S W
id>>X Z
)>>Z [
{?? 	
var@@ 
responseDto@@ 
=@@ 
await@@ #
_categoryService@@$ 4
.@@4 5
GetParentCategory@@5 F
(@@F G
id@@G I
)@@I J
;@@J K
returnAA 

StatusCodeAA 
(AA 
responseDtoAA )
.AA) *

StatusCodeAA* 4
,AA4 5
responseDtoAA6 A
)AAA B
;AAB C
}BB 	
[DD 	
HttpGetDD	 
]DD 
[EE 	
RouteEE	 
(EE 
$strEE 
)EE 
]EE 
[FF 	
	AuthorizeFF	 
]FF 
publicGG 
asyncGG 
TaskGG 
<GG 
ActionResultGG &
<GG& '
ResponseDTOGG' 2
>GG2 3
>GG3 4
GetByIdGG5 <
(GG< =
[GG= >
	FromRouteGG> G
]GGG H
GuidGGI M
idGGN P
)GGP Q
{HH 	
varII 

responeDtoII 
=II 
awaitII "
_categoryServiceII# 3
.II3 4
GetII4 7
(II7 8
UserII8 <
,II< =
idII> @
)II@ A
;IIA B
returnJJ 

StatusCodeJJ 
(JJ 

responeDtoJJ (
.JJ( )

StatusCodeJJ) 3
,JJ3 4

responeDtoJJ5 ?
)JJ? @
;JJ@ A
}KK 	
[NN 	
HttpPostNN	 
]NN 
publicOO 
asyncOO 
TaskOO 
<OO 
ActionResultOO &
<OO& '
ResponseDTOOO' 2
>OO2 3
>OO3 4
CreateOO5 ;
(OO; <
CreateCategoryDTOOO< M
createCategoryDtoOON _
)OO_ `
{PP 	
varQQ 

responeDtoQQ 
=QQ 
awaitQQ "
_categoryServiceQQ# 3
.QQ3 4
CreateCategoryQQ4 B
(QQB C
UserQQC G
,QQG H
createCategoryDtoQQI Z
)QQZ [
;QQ[ \
returnRR 

StatusCodeRR 
(RR 

responeDtoRR (
.RR( )

StatusCodeRR) 3
,RR3 4

responeDtoRR5 ?
)RR? @
;RR@ A
}SS 	
[UU 	
HttpPutUU	 
]UU 
publicVV 
asyncVV 
TaskVV 
<VV 
ActionResultVV &
<VV& '
ResponseDTOVV' 2
>VV2 3
>VV3 4
UpdateVV5 ;
(VV; <
[VV< =
FromBodyVV= E
]VVE F
UpdateCategoryDTOVVG X
updateCategoryDtoVVY j
)VVj k
{WW 	
varXX 

responeDtoXX 
=XX 
awaitXX "
_categoryServiceXX# 3
.XX3 4
UpdateXX4 :
(XX: ;
UserXX; ?
,XX? @
updateCategoryDtoXXA R
)XXR S
;XXS T
returnYY 

StatusCodeYY 
(YY 

responeDtoYY (
.YY( )

StatusCodeYY) 3
,YY3 4

responeDtoYY5 ?
)YY? @
;YY@ A
}ZZ 	
[\\ 	

HttpDelete\\	 
]\\ 
[]] 	
Route]]	 
(]] 
$str]] 
)]] 
]]] 
public^^ 
async^^ 
Task^^ 
<^^ 
ActionResult^^ &
<^^& '
ResponseDTO^^' 2
>^^2 3
>^^3 4
Delete^^5 ;
(^^; <
[^^< =
	FromRoute^^= F
]^^F G
Guid^^H L
id^^M O
)^^O P
{__ 	
var`` 

responeDto`` 
=`` 
await`` "
_categoryService``# 3
.``3 4
Delete``4 :
(``: ;
User``; ?
,``? @
id``A C
)``C D
;``D E
returnaa 

StatusCodeaa 
(aa 

responeDtoaa (
.aa( )

StatusCodeaa) 3
,aa3 4

responeDtoaa5 ?
)aa? @
;aa@ A
}bb 	
}cc 
}dd œÂ
gD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\AuthController.cs
	namespace		 	
Cursus		
 
.		 
LMS		 
.		 
API		 
.		 
Controllers		 $
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IEmailService &
_emailService' 4
;4 5
private 
readonly 
IAuthService %
_authService& 2
;2 3
private 
ResponseDTO 
responseDto '
=( )
new* -
ResponseDTO. 9
(9 :
): ;
;; <
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
AuthController 
( 
IEmailService +
emailService, 8
,8 9
IAuthService: F
authServiceG R
,R S
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
)4 5
{ 	
_emailService 
= 
emailService (
;( )
_authService 
= 
authService &
;& '
_userManager 
= 
userManager &
;& '
} 	
[   	
HttpPost  	 
]   
[!! 	
Route!!	 
(!! 
$str!!  
)!!  !
]!!! "
public"" 
async"" 
Task"" 
<"" 
ActionResult"" &
<""& '
ResponseDTO""' 2
>""2 3
>""3 4
SignUpStudent""5 B
(""B C
[""C D
FromBody""D L
]""L M
RegisterStudentDTO""N `
registerStudentDTO""a s
)""s t
{## 	
if$$ 
($$ 
!$$ 

ModelState$$ 
.$$ 
IsValid$$ #
)$$# $
{%% 
responseDto&& 
.&& 
	IsSuccess&& %
=&&& '
false&&( -
;&&- .
responseDto'' 
.'' 
Message'' #
=''$ %
$str''& ;
;''; <
responseDto(( 
.(( 
Result(( "
=((# $

ModelState((% /
.((/ 0
Values((0 6
.((6 7

SelectMany((7 A
(((A B
v((B C
=>((D F
v((G H
.((H I
Errors((I O
.((O P
Select((P V
(((V W
e((W X
=>((Y [
e((\ ]
.((] ^
ErrorMessage((^ j
)((j k
)((k l
;((l m
return)) 

BadRequest)) !
())! "
responseDto))" -
)))- .
;)). /
}** 
try,, 
{-- 
var.. 
result.. 
=.. 
await.. "
_authService..# /
.../ 0
SignUpStudent..0 =
(..= >
registerStudentDTO..> P
)..P Q
;..Q R
if// 
(// 
result// 
.// 
	IsSuccess// $
)//$ %
{00 
return11 
Ok11 
(11 
result11 $
)11$ %
;11% &
}22 
else33 
{44 
return55 

BadRequest55 %
(55% &
result55& ,
)55, -
;55- .
}66 
}77 
catch88 
(88 
	Exception88 
e88 
)88 
{99 
responseDto:: 
.:: 
	IsSuccess:: %
=::& '
false::( -
;::- .
responseDto;; 
.;; 
Message;; #
=;;$ %
e;;& '
.;;' (
Message;;( /
;;;/ 0
return<< 

StatusCode<< !
(<<! "
StatusCodes<<" -
.<<- .(
Status500InternalServerError<<. J
,<<J K
responseDto<<L W
)<<W X
;<<X Y
}== 
}>> 	
[DD 	
HttpPostDD	 
]DD 
[EE 	
RouteEE	 
(EE 
$strEE #
)EE# $
]EE$ %
publicFF 
asyncFF 
TaskFF 
<FF 
ActionResultFF &
<FF& '
ResponseDTOFF' 2
>FF2 3
>FF3 4
SignUpInstructorFF5 E
(FFE F
[GG 
FromBodyGG 
]GG 
SignUpInstructorDTOGG *
signUpInstructorDtoGG+ >
)GG> ?
{HH 	
varII 
resultII 
=II 
awaitII 
_authServiceII +
.II+ ,
SignUpInstructorII, <
(II< =
signUpInstructorDtoII= P
)IIP Q
;IIQ R
returnJJ 

StatusCodeJJ 
(JJ 
resultJJ $
.JJ$ %

StatusCodeJJ% /
,JJ/ 0
resultJJ1 7
)JJ7 8
;JJ8 9
}KK 	
[RR 	
HttpPostRR	 
]RR 
[SS 	
RouteSS	 
(SS 
$strSS )
)SS) *
]SS* +
[TT 	
	AuthorizeTT	 
]TT 
publicUU 
asyncUU 
TaskUU 
<UU 
ActionResultUU &
<UU& '
ResponseDTOUU' 2
>UU2 3
>UU3 4"
UploadInstructorDegreeUU5 K
(UUK L
DegreeUploadDTOUUL [
degreeUploadDtoUU\ k
)UUk l
{VV 	
varWW 
responseWW 
=WW 
awaitWW  
_authServiceWW! -
.WW- ."
UploadInstructorDegreeWW. D
(WWD E
degreeUploadDtoWWE T
.WWT U
FileWWU Y
,WWY Z
UserWW[ _
)WW_ `
;WW` a
returnXX 

StatusCodeXX 
(XX 
responseXX &
.XX& '

StatusCodeXX' 1
,XX1 2
responseXX3 ;
)XX; <
;XX< =
}YY 	
[__ 	
HttpGet__	 
]__ 
[`` 	
Route``	 
(`` 
$str`` &
)``& '
]``' (
[aa 	
	Authorizeaa	 
]aa 
publicbb 
asyncbb 
Taskbb 
<bb 
IActionResultbb '
>bb' (
GetInstructorDegreebb) <
(bb< =
[bb= >
	FromQuerybb> G
]bbG H
boolbbI M
DownloadbbN V
=bbW X
falsebbY ^
)bb^ _
{cc 	
vardd 
degreeResponseDtodd !
=dd" #
awaitdd$ )
_authServicedd* 6
.dd6 7
GetInstructorDegreedd7 J
(ddJ K
UserddK O
)ddO P
;ddP Q
ifee 
(ee 
degreeResponseDtoee !
.ee! "
Streamee" (
isee) +
nullee, 0
)ee0 1
{ff 
returngg 
NotFoundgg 
(gg  
$strgg  =
)gg= >
;gg> ?
}hh 
ifjj 
(jj 
Downloadjj 
)jj 
{kk 
returnll 
Filell 
(ll 
degreeResponseDtoll -
.ll- .
Streamll. 4
,ll4 5
degreeResponseDtoll6 G
.llG H
ContentTypellH S
,llS T
degreeResponseDtollU f
.llf g
FileNamellg o
)llo p
;llp q
}mm 
returnoo 
Fileoo 
(oo 
degreeResponseDtooo )
.oo) *
Streamoo* 0
,oo0 1
degreeResponseDtooo2 C
.ooC D
ContentTypeooD O
)ooO P
;ooP Q
}pp 	
[xx 	
HttpGetxx	 
]xx 
[yy 	
Routeyy	 
(yy 
$stryy 3
)yy3 4
]yy4 5
publiczz 
asynczz 
Taskzz 
<zz 
IActionResultzz '
>zz' (#
DisplayInstructorDegreezz) @
(zz@ A
[zzA B
	FromRoutezzB K
]zzK L
stringzzM S
userIdzzT Z
,zzZ [
[{{ 
	FromQuery{{ 
]{{ 
bool{{ 
Download{{ %
={{& '
false{{( -
){{- .
{|| 	
var}} 
degreeResponseDto}} !
=}}" #
await}}$ )
_authService}}* 6
.}}6 7#
DisplayInstructorDegree}}7 N
(}}N O
userId}}O U
)}}U V
;}}V W
if~~ 
(~~ 
degreeResponseDto~~ !
.~~! "
Stream~~" (
is~~) +
null~~, 0
)~~0 1
{ 
return
ÄÄ 
NotFound
ÄÄ 
(
ÄÄ  
$str
ÄÄ  =
)
ÄÄ= >
;
ÄÄ> ?
}
ÅÅ 
if
ÉÉ 
(
ÉÉ 
Download
ÉÉ 
)
ÉÉ 
{
ÑÑ 
return
ÖÖ 
File
ÖÖ 
(
ÖÖ 
degreeResponseDto
ÖÖ -
.
ÖÖ- .
Stream
ÖÖ. 4
,
ÖÖ4 5
degreeResponseDto
ÖÖ6 G
.
ÖÖG H
ContentType
ÖÖH S
,
ÖÖS T
degreeResponseDto
ÖÖU f
.
ÖÖf g
FileName
ÖÖg o
)
ÖÖo p
;
ÖÖp q
}
ÜÜ 
return
àà 
File
àà 
(
àà 
degreeResponseDto
àà )
.
àà) *
Stream
àà* 0
,
àà0 1
degreeResponseDto
àà2 C
.
ààC D
ContentType
ààD O
)
ààO P
;
ààP Q
}
ââ 	
[
êê 	
HttpPost
êê	 
]
êê 
[
ëë 	
Route
ëë	 
(
ëë 
$str
ëë #
)
ëë# $
]
ëë$ %
[
íí 	
	Authorize
íí	 
]
íí 
public
ìì 
async
ìì 
Task
ìì 
<
ìì 
ActionResult
ìì &
<
ìì& '
ResponseDTO
ìì' 2
>
ìì2 3
>
ìì3 4
UploadUserAvatar
ìì5 E
(
ììE F
AvatarUploadDTO
ììF U
avatarUploadDto
ììV e
)
ììe f
{
îî 	
var
ïï 
response
ïï 
=
ïï 
await
ïï  
_authService
ïï! -
.
ïï- .
UploadUserAvatar
ïï. >
(
ïï> ?
avatarUploadDto
ïï? N
.
ïïN O
File
ïïO S
,
ïïS T
User
ïïU Y
)
ïïY Z
;
ïïZ [
return
ññ 

StatusCode
ññ 
(
ññ 
response
ññ &
.
ññ& '

StatusCode
ññ' 1
,
ññ1 2
response
ññ3 ;
)
ññ; <
;
ññ< =
}
óó 	
[
ùù 	
HttpGet
ùù	 
]
ùù 
[
ûû 	
Route
ûû	 
(
ûû 
$str
ûû  
)
ûû  !
]
ûû! "
[
üü 	
	Authorize
üü	 
]
üü 
public
†† 
async
†† 
Task
†† 
<
†† 
IActionResult
†† '
>
††' (
GetUserAvatar
††) 6
(
††6 7
)
††7 8
{
°° 	
var
¢¢ 
stream
¢¢ 
=
¢¢ 
await
¢¢ 
_authService
¢¢ +
.
¢¢+ ,
GetUserAvatar
¢¢, 9
(
¢¢9 :
User
¢¢: >
)
¢¢> ?
;
¢¢? @
if
££ 
(
££ 
stream
££ 
is
££ 
null
££ 
)
££ 
{
§§ 
return
•• 
NotFound
•• 
(
••  
$str
••  =
)
••= >
;
••> ?
}
¶¶ 
return
®® 
File
®® 
(
®® 
stream
®® 
,
®® 
$str
®®  +
)
®®+ ,
;
®®, -
}
©© 	
[
ØØ 	
HttpGet
ØØ	 
]
ØØ 
[
∞∞ 	
Route
∞∞	 
(
∞∞ 
$str
∞∞ -
)
∞∞- .
]
∞∞. /
public
±± 
async
±± 
Task
±± 
<
±± 
IActionResult
±± '
>
±±' (
DisplayUserAvatar
±±) :
(
±±: ;
[
±±; <
	FromRoute
±±< E
]
±±E F
string
±±G M
userId
±±N T
)
±±T U
{
≤≤ 	
var
≥≥ 
stream
≥≥ 
=
≥≥ 
await
≥≥ 
_authService
≥≥ +
.
≥≥+ ,
DisplayUserAvatar
≥≥, =
(
≥≥= >
userId
≥≥> D
)
≥≥D E
;
≥≥E F
if
¥¥ 
(
¥¥ 
stream
¥¥ 
is
¥¥ 
null
¥¥ 
)
¥¥ 
{
µµ 
return
∂∂ 
NotFound
∂∂ 
(
∂∂  
$str
∂∂  =
)
∂∂= >
;
∂∂> ?
}
∑∑ 
return
ππ 
File
ππ 
(
ππ 
stream
ππ 
,
ππ 
$str
ππ  +
)
ππ+ ,
;
ππ, -
}
∫∫ 	
[
¿¿ 	
HttpPost
¿¿	 
]
¿¿ 
[
¡¡ 	
Route
¡¡	 
(
¡¡ 
$str
¡¡  
)
¡¡  !
]
¡¡! "
public
¬¬ 
async
¬¬ 
Task
¬¬ 
<
¬¬ 
ActionResult
¬¬ &
<
¬¬& '
ResponseDTO
¬¬' 2
>
¬¬2 3
>
¬¬3 4
ForgotPassword
¬¬5 C
(
¬¬C D
[
¬¬D E
FromBody
¬¬E M
]
¬¬M N
ForgotPasswordDTO
¬¬O `
forgotPasswordDto
¬¬a r
)
¬¬r s
{
√√ 	
var
ƒƒ 
result
ƒƒ 
=
ƒƒ 
await
ƒƒ 
_authService
ƒƒ +
.
ƒƒ+ ,
ForgotPassword
ƒƒ, :
(
ƒƒ: ;
forgotPasswordDto
ƒƒ; L
)
ƒƒL M
;
ƒƒM N
return
≈≈ 

StatusCode
≈≈ 
(
≈≈ 
result
≈≈ $
.
≈≈$ %

StatusCode
≈≈% /
,
≈≈/ 0
result
≈≈1 7
)
≈≈7 8
;
≈≈8 9
}
∆∆ 	
[
ÃÃ 	
HttpPost
ÃÃ	 
(
ÃÃ 
$str
ÃÃ "
)
ÃÃ" #
]
ÃÃ# $
public
ÕÕ 
async
ÕÕ 
Task
ÕÕ 
<
ÕÕ 
ActionResult
ÕÕ &
<
ÕÕ& '
ResponseDTO
ÕÕ' 2
>
ÕÕ2 3
>
ÕÕ3 4
ResetPassword
ÕÕ5 B
(
ÕÕB C
[
ÕÕC D
FromBody
ÕÕD L
]
ÕÕL M
ResetPasswordDTO
ÕÕN ^
resetPasswordDto
ÕÕ_ o
)
ÕÕo p
{
ŒŒ 	
var
œœ 
result
œœ 
=
œœ 
await
œœ 
_authService
œœ +
.
œœ+ ,
ResetPassword
œœ, 9
(
œœ9 :
resetPasswordDto
œœ: J
.
œœJ K
Email
œœK P
,
œœP Q
resetPasswordDto
œœR b
.
œœb c
Token
œœc h
,
œœh i
resetPasswordDto
––  
.
––  !
Password
––! )
)
––) *
;
––* +
return
—— 

StatusCode
—— 
(
—— 
result
—— $
.
——$ %

StatusCode
——% /
,
——/ 0
result
——1 7
)
——7 8
;
——8 9
}
““ 	
[
ŸŸ 	
HttpPost
ŸŸ	 
]
ŸŸ 
[
⁄⁄ 	
Route
⁄⁄	 
(
⁄⁄ 
$str
⁄⁄ "
)
⁄⁄" #
]
⁄⁄# $
public
€€ 
async
€€ 
Task
€€ 
<
€€ 
ActionResult
€€ &
<
€€& '
ResponseDTO
€€' 2
>
€€2 3
>
€€3 4
SendVerifyEmail
€€5 D
(
€€D E
[
€€E F
FromBody
€€F N
]
€€N O 
SendVerifyEmailDTO
€€P b
email
€€c h
)
€€h i
{
‹‹ 	
var
›› 
user
›› 
=
›› 
await
›› 
_userManager
›› )
.
››) *
FindByEmailAsync
››* :
(
››: ;
email
››; @
.
››@ A
Email
››A F
)
››F G
;
››G H
if
ﬁﬁ 
(
ﬁﬁ 
user
ﬁﬁ 
.
ﬁﬁ 
EmailConfirmed
ﬁﬁ #
)
ﬁﬁ# $
{
ﬂﬂ 
return
‡‡ 
new
‡‡ 
ResponseDTO
‡‡ &
(
‡‡& '
)
‡‡' (
{
·· 
	IsSuccess
‚‚ 
=
‚‚ 
true
‚‚  $
,
‚‚$ %
Message
„„ 
=
„„ 
$str
„„ =
,
„„= >

StatusCode
‰‰ 
=
‰‰  
$num
‰‰! $
,
‰‰$ %
Result
ÂÂ 
=
ÂÂ 
email
ÂÂ "
}
ÊÊ 
;
ÊÊ 
}
ÁÁ 
var
ÈÈ 
token
ÈÈ 
=
ÈÈ 
await
ÈÈ 
_userManager
ÈÈ *
.
ÈÈ* +1
#GenerateEmailConfirmationTokenAsync
ÈÈ+ N
(
ÈÈN O
user
ÈÈO S
)
ÈÈS T
;
ÈÈT U
var
ÎÎ 
confirmationLink
ÎÎ  
=
ÎÎ! "
$"
ÏÏ 
$str
ÏÏ N
{
ÏÏN O
user
ÏÏO S
.
ÏÏS T
Id
ÏÏT V
}
ÏÏV W
$str
ÏÏW ^
{
ÏÏ^ _
Uri
ÏÏ_ b
.
ÏÏb c
EscapeDataString
ÏÏc s
(
ÏÏs t
token
ÏÏt y
)
ÏÏy z
}
ÏÏz {
"
ÏÏ{ |
;
ÏÏ| }
var
ÓÓ 
responseDto
ÓÓ 
=
ÓÓ 
await
ÓÓ #
_authService
ÓÓ$ 0
.
ÓÓ0 1
SendVerifyEmail
ÓÓ1 @
(
ÓÓ@ A
user
ÓÓA E
.
ÓÓE F
Email
ÓÓF K
,
ÓÓK L
confirmationLink
ÓÓM ]
)
ÓÓ] ^
;
ÓÓ^ _
return
 

StatusCode
 
(
 
responseDto
 )
.
) *

StatusCode
* 4
,
4 5
responseDto
6 A
)
A B
;
B C
}
ÒÒ 	
[
ÛÛ 	
HttpPost
ÛÛ	 
]
ÛÛ 
[
ÙÙ 	
Route
ÙÙ	 
(
ÙÙ 
$str
ÙÙ 
)
ÙÙ 
]
ÙÙ 
[
ıı 	

ActionName
ıı	 
(
ıı 
$str
ıı "
)
ıı" #
]
ıı# $
public
ˆˆ 
async
ˆˆ 
Task
ˆˆ 
<
ˆˆ 
ActionResult
ˆˆ &
<
ˆˆ& '
ResponseDTO
ˆˆ' 2
>
ˆˆ2 3
>
ˆˆ3 4
VerifyEmail
ˆˆ5 @
(
ˆˆ@ A
[
˜˜ 
	FromQuery
˜˜ 
]
˜˜ 
string
˜˜ 
userId
˜˜ %
,
˜˜% &
[
¯¯ 
	FromQuery
¯¯ 
]
¯¯ 
string
¯¯ 
token
¯¯ $
)
¯¯$ %
{
˘˘ 	
var
˙˙ 
responseDto
˙˙ 
=
˙˙ 
await
˙˙ #
_authService
˙˙$ 0
.
˙˙0 1
VerifyEmail
˙˙1 <
(
˙˙< =
userId
˙˙= C
,
˙˙C D
token
˙˙E J
)
˙˙J K
;
˙˙K L
return
˚˚ 

StatusCode
˚˚ 
(
˚˚ 
responseDto
˚˚ )
.
˚˚) *

StatusCode
˚˚* 4
,
˚˚4 5
responseDto
˚˚6 A
)
˚˚A B
;
˚˚B C
}
¸¸ 	
[
ÇÇ 	
HttpPost
ÇÇ	 
]
ÇÇ 
[
ÉÉ 	
Route
ÉÉ	 
(
ÉÉ 
$str
ÉÉ  
)
ÉÉ  !
]
ÉÉ! "
[
ÑÑ 	
	Authorize
ÑÑ	 
]
ÑÑ 
public
ÖÖ 
async
ÖÖ 
Task
ÖÖ 
<
ÖÖ 
ActionResult
ÖÖ &
<
ÖÖ& '
ResponseDTO
ÖÖ' 2
>
ÖÖ2 3
>
ÖÖ3 4
ChangePassword
ÖÖ5 C
(
ÖÖC D
ChangePasswordDTO
ÖÖD U
changePasswordDto
ÖÖV g
)
ÖÖg h
{
ÜÜ 	
var
àà 
userId
àà 
=
àà 
User
àà 
.
àà 
FindFirstValue
àà ,
(
àà, -

ClaimTypes
àà- 7
.
àà7 8
NameIdentifier
àà8 F
)
ààF G
;
ààG H
var
ää 
response
ää 
=
ää 
await
ää  
_authService
ää! -
.
ää- .
ChangePassword
ää. <
(
ää< =
userId
ää= C
,
ääC D
changePasswordDto
ääE V
.
ääV W
OldPassword
ääW b
,
ääb c
changePasswordDto
ãã !
.
ãã! "
NewPassword
ãã" -
,
ãã- .
changePasswordDto
ãã/ @
.
ãã@ A 
ConfirmNewPassword
ããA S
)
ããS T
;
ããT U
if
çç 
(
çç 
response
çç 
.
çç 
	IsSuccess
çç "
)
çç" #
{
éé 
return
èè 
Ok
èè 
(
èè 
response
èè "
.
èè" #
Message
èè# *
)
èè* +
;
èè+ ,
}
êê 
else
ëë 
{
íí 
return
ìì 

BadRequest
ìì !
(
ìì! "
response
ìì" *
.
ìì* +
Message
ìì+ 2
)
ìì2 3
;
ìì3 4
}
îî 
}
ïï 	
[
úú 	
HttpPost
úú	 
]
úú 
[
ùù 	
Route
ùù	 
(
ùù 
$str
ùù 
)
ùù 
]
ùù 
public
ûû 
async
ûû 
Task
ûû 
<
ûû 
ActionResult
ûû &
<
ûû& '
ResponseDTO
ûû' 2
>
ûû2 3
>
ûû3 4
SignIn
ûû5 ;
(
ûû; <
[
ûû< =
FromBody
ûû= E
]
ûûE F
SignDTO
ûûG N
signDto
ûûO V
)
ûûV W
{
üü 	
var
†† 
responseDto
†† 
=
†† 
await
†† #
_authService
††$ 0
.
††0 1
SignIn
††1 7
(
††7 8
signDto
††8 ?
)
††? @
;
††@ A
return
°° 

StatusCode
°° 
(
°° 
this
°° "
.
°°" #
responseDto
°°# .
.
°°. /

StatusCode
°°/ 9
,
°°9 :
responseDto
°°; F
)
°°F G
;
°°G H
}
¢¢ 	
[
∏∏ 	
HttpPost
∏∏	 
]
∏∏ 
[
ππ 	
Route
ππ	 
(
ππ 
$str
ππ 
)
ππ 
]
ππ 
public
∫∫ 
async
∫∫ 
Task
∫∫ 
<
∫∫ 
ActionResult
∫∫ &
<
∫∫& '
ResponseDTO
∫∫' 2
>
∫∫2 3
>
∫∫3 4
Refresh
∫∫5 <
(
∫∫< =
[
∫∫= >
FromBody
∫∫> F
]
∫∫F G
JwtTokenDTO
∫∫H S
token
∫∫T Y
)
∫∫Y Z
{
ªª 	
var
ºº 
responseDto
ºº 
=
ºº 
await
ºº #
_authService
ºº$ 0
.
ºº0 1
Refresh
ºº1 8
(
ºº8 9
token
ºº9 >
.
ºº> ?
RefreshToken
ºº? K
)
ººK L
;
ººL M
return
ΩΩ 

StatusCode
ΩΩ 
(
ΩΩ 
responseDto
ΩΩ )
.
ΩΩ) *

StatusCode
ΩΩ* 4
,
ΩΩ4 5
responseDto
ΩΩ6 A
)
ΩΩA B
;
ΩΩB C
}
ææ 	
[
¿¿ 	
HttpPost
¿¿	 
]
¿¿ 
[
¡¡ 	
Route
¡¡	 
(
¡¡ 
$str
¡¡ "
)
¡¡" #
]
¡¡# $
public
¬¬ 
async
¬¬ 
Task
¬¬ 
<
¬¬ 
ActionResult
¬¬ &
<
¬¬& '
ResponseDTO
¬¬' 2
>
¬¬2 3
>
¬¬3 4
CheckEmailExist
¬¬5 D
(
¬¬D E
[
¬¬E F
FromBody
¬¬F N
]
¬¬N O
string
¬¬P V
email
¬¬W \
)
¬¬\ ]
{
√√ 	
var
ƒƒ 
responseDto
ƒƒ 
=
ƒƒ 
await
ƒƒ #
_authService
ƒƒ$ 0
.
ƒƒ0 1
CheckEmailExist
ƒƒ1 @
(
ƒƒ@ A
email
ƒƒA F
)
ƒƒF G
;
ƒƒG H
return
≈≈ 

StatusCode
≈≈ 
(
≈≈ 
this
≈≈ "
.
≈≈" #
responseDto
≈≈# .
.
≈≈. /

StatusCode
≈≈/ 9
,
≈≈9 :
responseDto
≈≈; F
)
≈≈F G
;
≈≈G H
}
∆∆ 	
[
»» 	
HttpPost
»»	 
]
»» 
[
…… 	
Route
……	 
(
…… 
$str
…… )
)
……) *
]
……* +
public
   
async
   
Task
   
<
   
ActionResult
   &
<
  & '
ResponseDTO
  ' 2
>
  2 3
>
  3 4#
CheckPhoneNumberExist
  5 J
(
  J K
[
  K L
FromBody
  L T
]
  T U
string
  V \
phoneNumber
  ] h
)
  h i
{
ÀÀ 	
var
ÃÃ 
responseDto
ÃÃ 
=
ÃÃ 
await
ÃÃ #
_authService
ÃÃ$ 0
.
ÃÃ0 1#
CheckPhoneNumberExist
ÃÃ1 F
(
ÃÃF G
phoneNumber
ÃÃG R
)
ÃÃR S
;
ÃÃS T
return
ÕÕ 

StatusCode
ÕÕ 
(
ÕÕ 
this
ÕÕ "
.
ÕÕ" #
responseDto
ÕÕ# .
.
ÕÕ. /

StatusCode
ÕÕ/ 9
,
ÕÕ9 :
responseDto
ÕÕ; F
)
ÕÕF G
;
ÕÕG H
}
ŒŒ 	
[
—— 	
HttpPost
——	 
]
—— 
[
““ 	
Route
““	 
(
““ 
$str
““ )
)
““) *
]
““* +
[
”” 	
	Authorize
””	 
]
”” 
public
‘‘ 
async
‘‘ 
Task
‘‘ 
<
‘‘ 
ActionResult
‘‘ &
<
‘‘& '
ResponseDTO
‘‘' 2
>
‘‘2 3
>
‘‘3 4$
CompleteStudentProfile
‘‘5 K
(
‘‘K L'
CompleteStudentProfileDTO
’’ %'
completeStudentProfileDto
’’& ?
)
’’? @
{
÷÷ 	
var
◊◊ 
responseDto
◊◊ 
=
◊◊ 
await
◊◊ #
_authService
◊◊$ 0
.
◊◊0 1$
CompleteStudentProfile
◊◊1 G
(
◊◊G H
User
◊◊H L
,
◊◊L M'
completeStudentProfileDto
◊◊N g
)
◊◊g h
;
◊◊h i
return
ÿÿ 

StatusCode
ÿÿ 
(
ÿÿ 
this
ÿÿ "
.
ÿÿ" #
responseDto
ÿÿ# .
.
ÿÿ. /

StatusCode
ÿÿ/ 9
,
ÿÿ9 :
responseDto
ÿÿ; F
)
ÿÿF G
;
ÿÿG H
}
ŸŸ 	
[
€€ 	
HttpPost
€€	 
]
€€ 
[
‹‹ 	
Route
‹‹	 
(
‹‹ 
$str
‹‹ ,
)
‹‹, -
]
‹‹- .
[
›› 	
	Authorize
››	 
]
›› 
public
ﬁﬁ 
async
ﬁﬁ 
Task
ﬁﬁ 
<
ﬁﬁ 
ActionResult
ﬁﬁ &
<
ﬁﬁ& '
ResponseDTO
ﬁﬁ' 2
>
ﬁﬁ2 3
>
ﬁﬁ3 4'
CompleteInstructorProfile
ﬁﬁ5 N
(
ﬁﬁN O*
CompleteInstructorProfileDTO
ﬂﬂ (*
completeInstructorProfileDto
ﬂﬂ) E
)
ﬂﬂE F
{
‡‡ 	
var
·· 
responseDto
·· 
=
·· 
await
·· #
_authService
··$ 0
.
··0 1'
CompleteInstructorProfile
··1 J
(
··J K
User
··K O
,
··O P*
completeInstructorProfileDto
··Q m
)
··m n
;
··n o
return
‚‚ 

StatusCode
‚‚ 
(
‚‚ 
responseDto
‚‚ )
.
‚‚) *

StatusCode
‚‚* 4
,
‚‚4 5
responseDto
‚‚6 A
)
‚‚A B
;
‚‚B C
}
„„ 	
[
ÂÂ 	
HttpPost
ÂÂ	 
]
ÂÂ 
[
ÊÊ 	
Route
ÊÊ	 
(
ÊÊ 
$str
ÊÊ "
)
ÊÊ" #
]
ÊÊ# $
public
ÁÁ 
async
ÁÁ 
Task
ÁÁ 
<
ÁÁ 
ActionResult
ÁÁ &
<
ÁÁ& '
ResponseDTO
ÁÁ' 2
>
ÁÁ2 3
>
ÁÁ3 4
SignInByGoogle
ÁÁ5 C
(
ÁÁC D
SignInByGoogleDTO
ÁÁD U
signInByGoogleDto
ÁÁV g
)
ÁÁg h
{
ËË 	
var
ÈÈ 
response
ÈÈ 
=
ÈÈ 
await
ÈÈ  
_authService
ÈÈ! -
.
ÈÈ- .
SignInByGoogle
ÈÈ. <
(
ÈÈ< =
signInByGoogleDto
ÈÈ= N
)
ÈÈN O
;
ÈÈO P
return
ÍÍ 

StatusCode
ÍÍ 
(
ÍÍ 
response
ÍÍ &
.
ÍÍ& '

StatusCode
ÍÍ' 1
,
ÍÍ1 2
response
ÍÍ3 ;
)
ÍÍ; <
;
ÍÍ< =
}
ÎÎ 	
[
ÌÌ 	
HttpGet
ÌÌ	 
]
ÌÌ 
[
ÓÓ 	
Route
ÓÓ	 
(
ÓÓ 
$str
ÓÓ 
)
ÓÓ 
]
ÓÓ  
public
ÔÔ 
async
ÔÔ 
Task
ÔÔ 
<
ÔÔ 
ActionResult
ÔÔ &
<
ÔÔ& '
ResponseDTO
ÔÔ' 2
>
ÔÔ2 3
>
ÔÔ3 4
GetUserInfo
ÔÔ5 @
(
ÔÔ@ A
)
ÔÔA B
{
 	
var
ÒÒ 
response
ÒÒ 
=
ÒÒ 
await
ÒÒ  
_authService
ÒÒ! -
.
ÒÒ- .
GetUserInfo
ÒÒ. 9
(
ÒÒ9 :
User
ÒÒ: >
)
ÒÒ> ?
;
ÒÒ? @
return
ÚÚ 

StatusCode
ÚÚ 
(
ÚÚ 
response
ÚÚ &
.
ÚÚ& '

StatusCode
ÚÚ' 1
,
ÚÚ1 2
response
ÚÚ3 ;
)
ÚÚ; <
;
ÚÚ< =
}
ÛÛ 	
}
ÙÙ 
}ıı 