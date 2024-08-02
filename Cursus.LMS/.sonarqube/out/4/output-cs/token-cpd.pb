�:
TD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. "
AddHttpContextAccessor '
(' (
)( )
;) *
builder 
. 
Services 
. 
AddHttpClient 
( 
)  
;  !
builder 
. 
Services 
. 
AddDbContext 
<  
ApplicationDbContext 2
>2 3
(3 4
options4 ;
=>< >
{ 
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C"
StaticConnectionStringC Y
.Y Z#
SQLDB_DefaultConnectionZ q
)q r
)r s
;s t
} 
) 
; 
builder 
. 
Services 
. 
	Configure 
< .
"DataProtectionTokenProviderOptions =
>= >
(> ?
options? F
=>G I
options 
. 
TokenLifespan 
= 
TimeSpan $
.$ %
FromMinutes% 0
(0 1
$num1 3
)3 4
)4 5
;5 6
builder   
.   
Services   
.   
AddAutoMapper   
(   
typeof   %
(  % &
AutoMapperProfile  & 7
)  7 8
)  8 9
;  9 :
builder$$ 
.$$ 
Services$$ 
.$$ 
RegisterServices$$ !
($$! "
)$$" #
;$$# $
builder(( 
.(( 
Services(( 
.(( 
AddFirebaseServices(( $
((($ %
)((% &
;((& '
builder,, 
.,, 
AddRedisCache,, 
(,, 
),, 
;,, 
builder00 
.00 
AddHangfireServices00 
(00 
)00 
;00 
builder22 
.22 
Services22 
.22 #
AddEndpointsApiExplorer22 (
(22( )
)22) *
;22* +
builder66 
.66  
AddAppAuthentication66 
(66 
)66 
;66 
builder88 
.88 
Services88 
.88 
AddAuthorization88 !
(88! "
)88" #
;88# $
builder<< 
.<< 
AddSwaggerGen<< 
(<< 
)<< 
;<< 
builder?? 
.?? 
Services?? 
.?? 

AddSignalR?? 
(?? 
)?? 
;?? 
builderAA 
.AA 
ServicesAA 
.AA 
AddCorsAA 
(AA 
optionsAA  
=>AA! #
{BB 
varCC 
originCC 
=CC 
builderCC 
.CC 
ConfigurationCC &
[CC& '
$strCC' =
]CC= >
;CC> ?
optionsDD 
.DD 
	AddPolicyDD 
(DD 
$strDD +
,DD+ ,
builderEE 
=>EE 
builderEE 
.FF 
WithOriginsFF 
(FF 
originFF 
)FF  
.GG 
AllowAnyHeaderGG 
(GG 
)GG 
.HH 
AllowAnyMethodHH 
(HH 
)HH 
.II 
AllowCredentialsII 
(II 
)II 
)II  
;II  !
}JJ 
)JJ 
;JJ 
builderMM 
.MM 
ServicesMM 
.MM +
AddApplicationInsightsTelemetryMM 0
(MM0 1
builderMM1 8
.MM8 9
ConfigurationMM9 F
[MMF G
$strMMG o
]MMo p
)MMp q
;MMq r
varOO 
appOO 
=OO 	
builderOO
 
.OO 
BuildOO 
(OO 
)OO 
;OO 
ApplyMigrationQQ 
(QQ 
)QQ 
;QQ 
StripeConfigurationSS 
.SS 
ApiKeySS 
=SS 
builderSS $
.SS$ %
ConfigurationSS% 2
.SS2 3

GetSectionSS3 =
(SS= >
$strSS> P
)SSP Q
.SSQ R
GetSSR U
<SSU V
stringSSV \
>SS\ ]
(SS] ^
)SS^ _
;SS_ `
ifVV 
(VV 
appVV 
.VV 
EnvironmentVV 
.VV 
IsDevelopmentVV !
(VV! "
)VV" #
)VV# $
{WW 
appXX 
.XX 

UseSwaggerXX 
(XX 
)XX 
;XX 
appYY 
.YY 
UseSwaggerUIYY 
(YY 
)YY 
;YY 
}ZZ 
app\\ 
.\\ 
UseCors\\ 
(\\ 
$str\\ !
)\\! "
;\\" #
app^^ 
.^^  
UseHangfireDashboard^^ 
(^^ 
)^^ 
;^^ 
app`` 
.``  
MapHangfireDashboard`` 
(`` 
$str`` $
)``$ %
;``% &
appbb 
.bb 
UseHttpsRedirectionbb 
(bb 
)bb 
;bb 
appdd 
.dd 
UseAuthenticationdd 
(dd 
)dd 
;dd 
appff 
.ff 
UseAuthorizationff 
(ff 
)ff 
;ff 
apphh 
.hh 
MapControllershh 
(hh 
)hh 
;hh 
appjj 
.jj 
MapHubjj 

<jj
 
NotificationHubjj 
>jj 
(jj 
$strjj 0
)jj0 1
.jj1 2 
RequireAuthorizationjj2 F
(jjF G
)jjG H
;jjH I
appll 
.ll 
Runll 
(ll 
)ll 	
;ll	 

voidnn 
ApplyMigrationnn 
(nn 
)nn 
{oo 
usingpp 	
(pp
 
varpp 
scopepp 
=pp 
apppp 
.pp 
Servicespp #
.pp# $
CreateScopepp$ /
(pp/ 0
)pp0 1
)pp1 2
{qq 
varrr 
contextrr 
=rr 
scoperr 
.rr 
ServiceProviderrr +
.rr+ ,
GetRequiredServicerr, >
<rr> ? 
ApplicationDbContextrr? S
>rrS T
(rrT U
)rrU V
;rrV W
iftt 

(tt 
contexttt 
.tt 
Databasett 
.tt  
GetPendingMigrationstt 1
(tt1 2
)tt2 3
.tt3 4
Anytt4 7
(tt7 8
)tt8 9
)tt9 :
{uu 	
contextvv 
.vv 
Databasevv 
.vv 
Migratevv $
(vv$ %
)vv% &
;vv& '
}ww 	
}xx 
}yy �*
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
}BB �8
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
services22 
.22 
	AddScoped22 
<22 
ICartService22 '
,22' (
CartService22) 4
>224 5
(225 6
)226 7
;227 8
services44 
.44 
	AddScoped44 
<44  
ICourseReviewService44 /
,44/ 0
CourseReviewService441 D
>44D E
(44E F
)44F G
;44G H
services66 
.66 
	AddScoped66 
<66  
ICourseReportService66 /
,66/ 0
CourseReportService661 D
>66D E
(66E F
)66F G
;66G H
services88 
.88 
	AddScoped88 
<88 
IOrderService88 (
,88( )
OrderService88* 6
>886 7
(887 8
)888 9
;889 :
services:: 
.:: 
	AddScoped:: 
<:: 
IOrderStatusService:: .
,::. /
OrderStatusService::0 B
>::B C
(::C D
)::D E
;::E F
services<< 
.<< 
	AddScoped<< 
<<< 
IStudentsService<< +
,<<+ ,
StudentService<<- ;
><<; <
(<<< =
)<<= >
;<<> ?
services>> 
.>> 
	AddScoped>> 
<>> !
IStudentCourseService>> 0
,>>0 1 
StudentCourseService>>2 F
>>>F G
(>>G H
)>>H I
;>>I J
services@@ 
.@@ 
	AddScoped@@ 
<@@ '
IStudentCourseStatusService@@ 6
,@@6 7&
StudentCourseStatusService@@8 R
>@@R S
(@@S T
)@@T U
;@@U V
servicesBB 
.BB 
	AddScopedBB 
<BB 
IStripeServiceBB )
,BB) *
StripeServiceBB+ 8
>BB8 9
(BB9 :
)BB: ;
;BB; <
servicesDD 
.DD 
	AddScopedDD 
<DD 
ITransactionServiceDD .
,DD. /
TransactionServiceDD0 B
>DDB C
(DDC D
)DDD E
;DDE F
servicesFF 
.FF 
	AddScopedFF 
<FF 
IBalanceServiceFF *
,FF* +
BalanceServiceFF, :
>FF: ;
(FF; <
)FF< =
;FF= >
servicesHH 
.HH 
	AddScopedHH 
<HH 
IPaymentServiceHH *
,HH* +
PaymentServiceHH, :
>HH: ;
(HH; <
)HH< =
;HH= >
servicesKK 
.KK 
AddIdentityKK 
<KK 
ApplicationUserKK ,
,KK, -
IdentityRoleKK. :
>KK: ;
(KK; <
)KK< =
.LL $
AddEntityFrameworkStoresLL %
<LL% & 
ApplicationDbContextLL& :
>LL: ;
(LL; <
)LL< =
.MM $
AddDefaultTokenProvidersMM %
(MM% &
)MM& '
;MM' (
returnPP 
servicesPP 
;PP 
}QQ 
}RR �

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
} �
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
} �
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
} �7
jD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\PaymentController.cs
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
class 
PaymentController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IPaymentService (
_paymentService) 8
;8 9
private 
readonly 
ITransactionService ,
_transactionService- @
;@ A
public 
PaymentController  
(  !
IPaymentService! 0
paymentService1 ?
,? @
ITransactionServiceA T
transactionServiceU g
)g h
{ 	
_paymentService 
= 
paymentService ,
;, -
_transactionService 
=  !
transactionService" 4
;4 5
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4!
GetTransactionHistory5 J
( 	
[ 
	FromQuery 
] 
string 
? 
userId  &
,& '
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[   
	FromQuery   
]   
bool   
?   
isAscending   )
,  ) *
[!! 
	FromQuery!! 
]!! 
int!! 

pageNumber!! &
=!!' (
$num!!) *
,!!* +
["" 
	FromQuery"" 
]"" 
int"" 
pageSize"" $
=""% &
$num""' (
)## 	
{$$ 	
var%% 
responseDto%% 
=%% 
await%% #
_transactionService%%$ 7
.%%7 8
GetTransactions%%8 G
(&& 
User'' 
,'' 
userId(( 
,(( 
filterOn)) 
,)) 
filterQuery** 
,** 
sortBy++ 
,++ 
isAscending,, 
,,, 

pageNumber-- 
,-- 
pageSize.. 
)// 
;// 
return00 

StatusCode00 
(00 
responseDto00 )
.00) *

StatusCode00* 4
,004 5
responseDto006 A
)00A B
;00B C
}11 	
[44 	
HttpPost44	 
]44 
[55 	
Route55	 
(55 
$str55 
)55  
]55  !
public66 
async66 
Task66 
<66 
ActionResult66 &
<66& '
ResponseDTO66' 2
>662 3
>663 4(
CreateStripeConnectedAccount665 Q
(77 	+
CreateStripeConnectedAccountDTO88 ++
createStripeConnectedAccountDto88, K
)99 	
{:: 	
var;; 
responseDto;; 
=;; 
await;; #
_paymentService;;$ 3
.;;3 4(
CreateStripeConnectedAccount;;4 P
(;;P Q+
createStripeConnectedAccountDto;;Q p
);;p q
;;;q r
return<< 

StatusCode<< 
(<< 
responseDto<< )
.<<) *

StatusCode<<* 4
,<<4 5
responseDto<<6 A
)<<A B
;<<B C
}== 	
[?? 	
HttpPost??	 
]?? 
[@@ 	
Route@@	 
(@@ 
$str@@  
)@@  !
]@@! "
publicAA 
asyncAA 
TaskAA 
<AA 
ActionResultAA &
<AA& '
ResponseDTOAA' 2
>AA2 3
>AA3 4 
CreateStripeTransferAA5 I
(BB 	#
CreateStripeTransferDTOCC ##
createStripeTransferDtoCC$ ;
)CC; <
{DD 	
varEE 
responseDtoEE 
=EE 
awaitEE #
_paymentServiceEE$ 3
.EE3 4 
CreateStripeTransferEE4 H
(EEH I#
createStripeTransferDtoEEI `
)EE` a
;EEa b
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
[II 	
HttpPostII	 
]II 
[JJ 	
RouteJJ	 
(JJ 
$strJJ 
)JJ 
]JJ  
[KK 	
	AuthorizeKK	 
(KK 
RolesKK 
=KK 
StaticUserRolesKK *
.KK* +

InstructorKK+ 5
)KK5 6
]KK6 7
publicLL 
asyncLL 
TaskLL 
<LL 
ActionResultLL &
<LL& '
ResponseDTOLL' 2
>LL2 3
>LL3 4
CreateStripePayoutLL5 G
(LLG H!
CreateStripePayoutDTOLLH ]!
createStripePayoutDtoLL^ s
)LLs t
{MM 	
varNN 
responseDtoNN 
=NN 
awaitNN #
_paymentServiceNN$ 3
.NN3 4
CreateStripePayoutNN4 F
(NNF G
UserNNG K
,NNK L!
createStripePayoutDtoNNM b
)NNb c
;NNc d
returnOO 

StatusCodeOO 
(OO 
responseDtoOO )
.OO) *

StatusCodeOO* 4
,OO4 5
responseDtoOO6 A
)OOA B
;OOB C
}PP 	
[RR 	
HttpPostRR	 
]RR 
[SS 	
RouteSS	 
(SS 
$strSS 
)SS 
]SS 
publicTT 
asyncTT 
TaskTT 
<TT 
ActionResultTT &
<TT& '
ResponseDTOTT' 2
>TT2 3
>TT3 4
AddStripeCardTT5 B
(UU 	
AddStripeCardDTOVV 
addStripeCardDtoVV -
)WW 	
{XX 	
varYY 
responseDtoYY 
=YY 
awaitYY #
_paymentServiceYY$ 3
.YY3 4
AddStripeCardYY4 A
(YYA B
addStripeCardDtoYYB R
)YYR S
;YYS T
returnZZ 

StatusCodeZZ 
(ZZ 
responseDtoZZ )
.ZZ) *

StatusCodeZZ* 4
,ZZ4 5
responseDtoZZ6 A
)ZZA B
;ZZB C
}[[ 	
}
�� 
}�� ҟ
jD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\StudentController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
StudentController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IStudentsService )
_studentsService* :
;: ;
public 
StudentController  
(  !
IStudentsService! 1
studentsService2 A
)A B
{ 	
_studentsService 
= 
studentsService .
;. /
} 	
[ 	
HttpGet	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
StaticUserRoles *
.* +
Admin+ 0
)0 1
]1 2
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetAllStudent5 B
( 	
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
)"" 	
{## 	
var$$ 
responseDto$$ 
=$$ 
await%% 
_studentsService%% &
.%%& '
GetAllStudent%%' 4
(%%4 5
User%%5 9
,%%9 :
filterOn%%; C
,%%C D
filterQuery%%E P
,%%P Q
sortBy%%R X
,%%X Y
isAscending%%Z e
,%%e f

pageNumber%%g q
,%%q r
pageSize&& 
)&& 
;&& 
return'' 

StatusCode'' 
('' 
responseDto'' )
.'') *

StatusCode''* 4
,''4 5
responseDto''6 A
)''A B
;''B C
}(( 	
[** 	
HttpGet**	 
]** 
[++ 	
Route++	 
(++ 
$str++ !
)++! "
]++" #
[,, 	
	Authorize,,	 
(,, 
Roles,, 
=,, 
StaticUserRoles,, *
.,,* +
Admin,,+ 0
),,0 1
],,1 2
public-- 
async-- 
Task-- 
<-- 
ActionResult-- &
<--& '
ResponseDTO--' 2
>--2 3
>--3 4
GetStudentById--5 C
(--C D
[--D E
	FromRoute--E N
]--N O
Guid--P T
	studentId--U ^
)--^ _
{.. 	
var// 
responseDto// 
=// 
await// #
_studentsService//$ 4
.//4 5
GetById//5 <
(//< =
	studentId//= F
)//F G
;//G H
return00 

StatusCode00 
(00 
responseDto00 )
.00) *

StatusCode00* 4
,004 5
responseDto006 A
)00A B
;00B C
}11 	
[33 	
HttpPut33	 
]33 
[44 	
	Authorize44	 
(44 
Roles44 
=44 
StaticUserRoles44 *
.44* +
Admin44+ 0
)440 1
]441 2
public55 
async55 
Task55 
<55 
ActionResult55 &
<55& '
ResponseDTO55' 2
>552 3
>553 4
UpdateStudent555 B
(55B C
[55C D
FromBody55D L
]55L M
UpdateStudentDTO55N ^
updateStudentDTO55_ o
)55o p
{66 	
var77 
responseDto77 
=77 
await77 #
_studentsService77$ 4
.774 5

UpdateById775 ?
(77? @
updateStudentDTO77@ P
)77P Q
;77Q R
return88 

StatusCode88 
(88 
responseDto88 )
.88) *

StatusCode88* 4
,884 5
responseDto886 A
)88A B
;88B C
}99 	
[;; 	
HttpPost;;	 
];; 
[<< 	
Route<<	 
(<< 
$str<< *
)<<* +
]<<+ ,
[== 	
	Authorize==	 
(== 
Roles== 
=== 
StaticUserRoles== *
.==* +
Admin==+ 0
)==0 1
]==1 2
public>> 
async>> 
Task>> 
<>> 
ActionResult>> &
<>>& '
ResponseDTO>>' 2
>>>2 3
>>>3 4
ActivateStudent>>5 D
(>>D E
[>>E F
	FromRoute>>F O
]>>O P
Guid>>Q U
	studentId>>V _
)>>_ `
{?? 	
var@@ 
responseDto@@ 
=@@ 
await@@ #
_studentsService@@$ 4
.@@4 5
ActivateStudent@@5 D
(@@D E
User@@E I
,@@I J
	studentId@@K T
)@@T U
;@@U V
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
[DD 	
HttpPostDD	 
]DD 
[EE 	
RouteEE	 
(EE 
$strEE ,
)EE, -
]EE- .
[FF 	
	AuthorizeFF	 
(FF 
RolesFF 
=FF 
StaticUserRolesFF *
.FF* +
AdminFF+ 0
)FF0 1
]FF1 2
publicGG 
asyncGG 
TaskGG 
<GG 
ActionResultGG &
<GG& '
ResponseDTOGG' 2
>GG2 3
>GG3 4
DeactiveStudentGG5 D
(GGD E
[GGE F
	FromRouteGGF O
]GGO P
GuidGGQ U
	studentIdGGV _
)GG_ `
{HH 	
varII 
responseDtoII 
=II 
awaitII #
_studentsServiceII$ 4
.II4 5
DeactivateStudentII5 F
(IIF G
UserIIG K
,IIK L
	studentIdIIM V
)IIV W
;IIW X
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
[MM 	
HttpGetMM	 
]MM 
[NN 	
RouteNN	 
(NN 
$strNN .
)NN. /
]NN/ 0
[OO 	
	AuthorizeOO	 
(OO 
RolesOO 
=OO 
StaticUserRolesOO *
.OO* +
AdminOO+ 0
)OO0 1
]OO1 2
publicPP 
asyncPP 
TaskPP 
<PP 
ActionResultPP &
<PP& '
ResponseDTOPP' 2
>PP2 3
>PP3 4&
GetTotalCoursesStudentByIdPP5 O
(PPO P
[PPP Q
	FromRoutePPQ Z
]PPZ [
GuidPP\ `
	studentIdPPa j
)PPj k
{QQ 	
varRR 
responseDtoRR 
=RR 
awaitRR #
_studentsServiceRR$ 4
.RR4 5"
GetStudentTotalCoursesRR5 K
(RRK L
	studentIdRRL U
)RRU V
;RRV W
returnSS 

StatusCodeSS 
(SS 
responseDtoSS )
.SS) *

StatusCodeSS* 4
,SS4 5
responseDtoSS6 A
)SSA B
;SSB C
}TT 	
[VV 	
HttpGetVV	 
]VV 
[WW 	
RouteWW	 
(WW 
$strWW )
)WW) *
]WW* +
[XX 	
	AuthorizeXX	 
(XX 
RolesXX 
=XX 
StaticUserRolesXX *
.XX* +
AdminXX+ 0
)XX0 1
]XX1 2
publicYY 
asyncYY 
TaskYY 
<YY 
ActionResultYY &
<YY& '
ResponseDTOYY' 2
>YY2 3
>YY3 4
GetStudentCommentsYY5 G
(ZZ 	
[[[ 
	FromRoute[[ 
][[ 
Guid[[ 
	studentId[[ &
,[[& '
[\\ 
	FromQuery\\ 
]\\ 
int\\ 

pageNumber\\ &
=\\' (
$num\\) *
,\\* +
[]] 
	FromQuery]] 
]]] 
int]] 
pageSize]] $
=]]% &
$num]]' )
)^^ 	
{__ 	
var`` 
responseDto`` 
=`` 
await`` #
_studentsService``$ 4
.``4 5 
GetAllStudentComment``5 I
(``I J
	studentId``J S
,``S T

pageNumber``U _
,``_ `
pageSize``a i
)``i j
;``j k
returnaa 

StatusCodeaa 
(aa 
responseDtoaa )
.aa) *

StatusCodeaa* 4
,aa4 5
responseDtoaa6 A
)aaA B
;aaB C
}bb 	
[dd 	
HttpPostdd	 
]dd 
[ee 	
Routeee	 
(ee 
$stree 
)ee 
]ee 
[ff 	
	Authorizeff	 
(ff 
Rolesff 
=ff 
StaticUserRolesff *
.ff* +
Adminff+ 0
)ff0 1
]ff1 2
publicgg 
asyncgg 
Taskgg 
<gg 
ActionResultgg &
<gg& '
ResponseDTOgg' 2
>gg2 3
>gg3 4 
CreateStudentCommentgg5 I
(ggI J#
CreateStudentCommentDTOhh ##
createStudentCommentDtohh$ ;
)hh; <
{ii 	
varjj 
responseDtojj 
=jj 
awaitjj #
_studentsServicejj$ 4
.jj4 5 
CreateStudentCommentjj5 I
(jjI J
UserjjJ N
,jjN O#
createStudentCommentDtojjP g
)jjg h
;jjh i
returnkk 

StatusCodekk 
(kk 
responseDtokk )
.kk) *

StatusCodekk* 4
,kk4 5
responseDtokk6 A
)kkA B
;kkB C
}ll 	
[nn 	
HttpPutnn	 
]nn 
[oo 	
Routeoo	 
(oo 
$stroo 
)oo 
]oo 
[pp 	
	Authorizepp	 
(pp 
Rolespp 
=pp 
StaticUserRolespp *
.pp* +
Adminpp+ 0
)pp0 1
]pp1 2
publicqq 
asyncqq 
Taskqq 
<qq 
ActionResultqq &
<qq& '
ResponseDTOqq' 2
>qq2 3
>qq3 4 
UpdateStudentCommentqq5 I
(qqI J#
UpdateStudentCommentDTOrr ##
updateStudentCommentDtorr$ ;
)rr; <
{ss 	
vartt 
responseDtott 
=tt 
awaittt #
_studentsServicett$ 4
.tt4 5 
UpdateStudentCommenttt5 I
(ttI J
UserttJ N
,ttN O#
updateStudentCommentDtottP g
)ttg h
;tth i
returnuu 

StatusCodeuu 
(uu 
responseDtouu )
.uu) *

StatusCodeuu* 4
,uu4 5
responseDtouu6 A
)uuA B
;uuB C
}vv 	
[xx 	

HttpDeletexx	 
]xx 
[yy 	
Routeyy	 
(yy 
$stryy )
)yy) *
]yy* +
[zz 	
	Authorizezz	 
(zz 
Roleszz 
=zz 
StaticUserRoleszz *
.zz* +
Adminzz+ 0
)zz0 1
]zz1 2
public{{ 
async{{ 
Task{{ 
<{{ 
ActionResult{{ &
<{{& '
ResponseDTO{{' 2
>{{2 3
>{{3 4 
DeleteStudentComment{{5 I
({{I J
[{{J K
	FromRoute{{K T
]{{T U
Guid{{V Z
	commentId{{[ d
){{d e
{|| 	
var}} 
responseDto}} 
=}} 
await}} #
_studentsService}}$ 4
.}}4 5 
DeleteStudentComment}}5 I
(}}I J
	commentId}}J S
)}}S T
;}}T U
return~~ 

StatusCode~~ 
(~~ 
responseDto~~ )
.~~) *

StatusCode~~* 4
,~~4 5
responseDto~~6 A
)~~A B
;~~B C
} 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� .
)
��. /
]
��/ 0
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
ExportStudent
��5 B
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
int
�� 
month
�� !
,
��! "
[
�� 
	FromRoute
�� 
]
�� 
int
�� 
year
��  
)
�� 	
{
�� 	
var
�� 
userId
�� 
=
�� 
User
�� 
.
�� 
Claims
�� $
.
��$ %
FirstOrDefault
��% 3
(
��3 4
x
��4 5
=>
��6 8
x
��9 :
.
��: ;
Type
��; ?
==
��@ B

ClaimTypes
��C M
.
��M N
NameIdentifier
��N \
)
��\ ]
?
��] ^
.
��^ _
Value
��_ d
;
��d e
BackgroundJob
�� 
.
�� 
Enqueue
�� !
<
��! "
IStudentsService
��" 2
>
��2 3
(
��3 4
job
��4 7
=>
��8 :
job
��; >
.
��> ?
ExportStudents
��? M
(
��M N
userId
��N T
,
��T U
month
��V [
,
��[ \
year
��] a
)
��a b
)
��b c
;
��c d
return
�� 
Ok
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� $
)
��$ %
]
��% &
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (#
DownloadStudentExport
��) >
(
��> ?
[
��? @
	FromRoute
��@ I
]
��I J
string
��K Q
fileName
��R Z
)
��Z [
{
�� 	
var
�� "
closedXmlResponseDto
�� $
=
��% &
await
��' ,
_studentsService
��- =
.
��= >
DownloadStudents
��> N
(
��N O
fileName
��O W
)
��W X
;
��X Y
var
�� 
stream
�� 
=
�� "
closedXmlResponseDto
�� -
.
��- .
Stream
��. 4
;
��4 5
var
�� 
contentType
�� 
=
�� "
closedXmlResponseDto
�� 2
.
��2 3
ContentType
��3 >
;
��> ?
if
�� 
(
�� 
stream
�� 
is
�� 
null
�� 
||
�� !
contentType
��" -
is
��. 0
null
��1 5
)
��5 6
{
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
}
�� 
return
�� 
File
�� 
(
�� 
stream
�� 
,
�� 
contentType
��  +
,
��+ ,
fileName
��- 5
)
��5 6
;
��6 7
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 4
)
��4 5
]
��5 6
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
AdminStudent
��+ 7
)
��7 8
]
��8 9
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4*
TotalPricesCourseByStudentId
��5 Q
(
��Q R
[
��R S
	FromRoute
��S \
]
��\ ]
Guid
��^ b
	studentId
��c l
)
��l m
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_studentsService
��$ 4
.
��4 5+
TotalPricesCoursesByStudentId
��5 R
(
��R S
	studentId
��S \
)
��\ ]
;
��] ^
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� (
)
��( )
]
��) *
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
AdminStudent
��+ 7
)
��7 8
]
��8 9
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4&
GetAllCoursesByStudentId
��5 M
(
��M N
[
��N O
	FromRoute
��O X
]
��X Y
Guid
��Z ^
	studentId
��_ h
)
��h i
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_studentsService
��$ 4
.
��4 5%
GetAllCourseByStudentId
��5 L
(
��L M
	studentId
��M V
)
��V W
;
��W X
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 5
)
��5 6
]
��6 7
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
AdminStudent
��+ 7
)
��7 8
]
��8 9
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4*
GetAllCoursesStudentEnrolled
��5 Q
(
��Q R
[
��R S
	FromRoute
��S \
]
��\ ]
Guid
��^ b
	studentId
��c l
)
��l m
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_studentsService
��$ 4
.
��4 5)
GetAllCourseStudentEnrolled
��5 P
(
��P Q
	studentId
��Q Z
)
��Z [
;
��[ \
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
}
�� 
}�� �<
hD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\OrderController.cs
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
class 
OrderController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IOrderService &
_orderService' 4
;4 5
public 
OrderController 
( 
IOrderService ,
orderService- 9
)9 :
{ 	
_orderService 
= 
orderService (
;( )
} 	
[ 	
HttpPost	 
] 
[ 	
	Authorize	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
CreateOrder5 @
(@ A
)A B
{ 	
var 
responseDto 
= 
await #
_orderService$ 1
.1 2
CreateOrder2 =
(= >
User> B
)B C
;C D
return 

StatusCode 
( 
responseDto )
.) *

StatusCode* 4
,4 5
responseDto6 A
)A B
;B C
} 	
[ 	
HttpGet	 
] 
[ 	
	Authorize	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
	GetOrders5 >
( 	
[   
	FromQuery   
]   
Guid   
?   
	studentId   '
,  ' (
[!! 
	FromQuery!! 
]!! 
string!! 
?!! 
filterOn!!  (
,!!( )
["" 
	FromQuery"" 
]"" 
string"" 
?"" 
filterQuery""  +
,""+ ,
[## 
	FromQuery## 
]## 
string## 
?## 
sortBy##  &
,##& '
[$$ 
	FromQuery$$ 
]$$ 
bool$$ 
?$$ 
isAscending$$ )
,$$) *
[%% 
	FromQuery%% 
]%% 
int%% 

pageNumber%% &
=%%' (
$num%%) *
,%%* +
[&& 
	FromQuery&& 
]&& 
int&& 
pageSize&& $
=&&% &
$num&&' (
)'' 	
{(( 	
var)) 
responseDto)) 
=)) 
await)) #
_orderService))$ 1
.))1 2
	GetOrders))2 ;
(** 
User++ 
,++ 
	studentId,, 
,,, 
filterOn-- 
,-- 
filterQuery.. 
,.. 
sortBy// 
,// 
isAscending00 
,00 

pageNumber11 
,11 
pageSize22 
)33 
;33 
return55 

StatusCode55 
(55 
responseDto55 )
.55) *

StatusCode55* 4
,554 5
responseDto556 A
)55A B
;55B C
}66 	
[88 	
HttpGet88	 
]88 
[99 	
Route99	 
(99 
$str99 %
)99% &
]99& '
[:: 	
	Authorize::	 
]:: 
public;; 
async;; 
Task;; 
<;; 
ActionResult;; &
<;;& '
ResponseDTO;;' 2
>;;2 3
>;;3 4
GetOrder;;5 =
(;;= >
[;;> ?
	FromRoute;;? H
];;H I
Guid;;J N
orderHeaderId;;O \
);;\ ]
{<< 	
var== 
responseDto== 
=== 
await== #
_orderService==$ 1
.==1 2
GetOrder==2 :
(==: ;
User==; ?
,==? @
orderHeaderId==A N
)==N O
;==O P
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
$strBB  
)BB  !
]BB! "
[CC 	
	AuthorizeCC	 
]CC 
publicDD 
asyncDD 
TaskDD 
<DD 
ActionResultDD &
<DD& '
ResponseDTODD' 2
>DD2 3
>DD3 4
PayWithStripeDD5 B
(EE 	
[FF 
FromBodyFF 
]FF 
PayWithStripeDTOFF '
payWithStripeDtoFF( 8
)GG 	
{HH 	
varII 
responseDtoII 
=II 
awaitII #
_orderServiceII$ 1
.II1 2
PayWithStripeII2 ?
(II? @
UserII@ D
,IID E
payWithStripeDtoIIF V
)IIV W
;IIW X
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
$strNN  
)NN  !
]NN! "
[OO 	
	AuthorizeOO	 
]OO 
publicPP 
asyncPP 
TaskPP 
<PP 
ActionResultPP &
<PP& '
ResponseDTOPP' 2
>PP2 3
>PP3 4
ValidateWithStripePP5 G
(QQ 	
[RR 
FromBodyRR 
]RR !
ValidateWithStripeDTORR ,!
validateWithStripeDtoRR- B
)SS 	
{TT 	
varUU 
responseDtoUU 
=UU 
awaitUU #
_orderServiceUU$ 1
.UU1 2
ValidateWithStripeUU2 D
(UUD E
UserUUE I
,UUI J!
validateWithStripeDtoUUK `
)UU` a
;UUa b
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
$strZZ -
)ZZ- .
]ZZ. /
[[[ 	
	Authorize[[	 
([[ 
Roles[[ 
=[[ 
StaticUserRoles[[ *
.[[* +
Admin[[+ 0
)[[0 1
][[1 2
public\\ 
async\\ 
Task\\ 
<\\ 
ActionResult\\ &
<\\& '
ResponseDTO\\' 2
>\\2 3
>\\3 4
ConfirmOrder\\5 A
(\\A B
[\\B C
	FromRoute\\C L
]\\L M
Guid\\N R
orderHeaderId\\S `
)\\` a
{]] 	
var^^ 
responseDto^^ 
=^^ 
await^^ #
_orderService^^$ 1
.^^1 2
ConfirmOrder^^2 >
(^^> ?
User^^? C
,^^C D
orderHeaderId^^E R
)^^R S
;^^S T
return__ 

StatusCode__ 
(__ 
responseDto__ )
.__) *

StatusCode__* 4
,__4 5
responseDto__6 A
)__A B
;__B C
}`` 	
}aa 
}bb �1
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
}YY ��
mD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\InstructorController.cs
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
class  
InstructorController %
:& '
ControllerBase( 6
{ 
private 
readonly 
IInstructorService +
_instructorService, >
;> ?
private 
readonly 
IPaymentService (
_paymentService) 8
;8 9
public  
InstructorController #
(# $
IInstructorService$ 6
instructorService7 H
,H I
IPaymentServiceJ Y
paymentServiceZ h
)h i
{ 	
_instructorService 
=  
instructorService! 2
;2 3
_paymentService 
= 
paymentService ,
;, -
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetAllInstructor5 E
( 	
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[ 
	FromQuery 
] 
string 
? 
sortBy  &
,& '
[ 
	FromQuery 
] 
bool 
? 
isAscending )
,) *
[ 
	FromQuery 
] 
int 

pageNumber &
=' (
$num) *
,* +
[   
	FromQuery   
]   
int   
pageSize   $
=  % &
$num  ' )
)!! 	
{"" 	
var## 
responseDto## 
=## 
await$$ 
_instructorService$$ (
.$$( )
GetAll$$) /
($$/ 0
User$$0 4
,$$4 5
filterOn$$6 >
,$$> ?
filterQuery$$@ K
,$$K L
sortBy$$M S
,$$S T
isAscending$$U `
,$$` a

pageNumber$$b l
,$$l m
pageSize$$n v
)$$v w
;$$w x
return%% 

StatusCode%% 
(%% 
responseDto%% )
.%%) *

StatusCode%%* 4
,%%4 5
responseDto%%6 A
)%%A B
;%%B C
}&& 	
[(( 	
HttpGet((	 
](( 
[)) 	
Route))	 
()) 
$str)) $
)))$ %
]))% &
public** 
async** 
Task** 
<** 
ActionResult** &
<**& '
ResponseDTO**' 2
>**2 3
>**3 4
GetInstructorById**5 F
(**F G
[**G H
	FromRoute**H Q
]**Q R
Guid**S W
instructorId**X d
)**d e
{++ 	
var,, 
responseDto,, 
=,, 
await,, #
_instructorService,,$ 6
.,,6 7
GetById,,7 >
(,,> ?
instructorId,,? K
),,K L
;,,L M
return-- 

StatusCode-- 
(-- 
responseDto-- )
.--) *

StatusCode--* 4
,--4 5
responseDto--6 A
)--A B
;--B C
}.. 	
[00 	
HttpGet00	 
]00 
[11 	
Route11	 
(11 
$str11 1
)111 2
]112 3
public22 
async22 
Task22 
<22 
ActionResult22 &
<22& '
ResponseDTO22' 2
>222 3
>223 4)
GetTotalCoursesInstructorById225 R
(22R S
[22S T
	FromRoute22T ]
]22] ^
Guid22_ c
instructorId22d p
)22p q
{33 	
var44 
responseDto44 
=44 
await44 #
_instructorService44$ 6
.446 7%
GetInstructorTotalCourses447 P
(44P Q
instructorId44Q ]
)44] ^
;44^ _
return55 

StatusCode55 
(55 
responseDto55 )
.55) *

StatusCode55* 4
,554 5
responseDto556 A
)55A B
;55B C
}66 	
[88 	
HttpGet88	 
]88 
[99 	
Route99	 
(99 
$str99 1
)991 2
]992 3
public:: 
async:: 
Task:: 
<:: 
ActionResult:: &
<::& '
ResponseDTO::' 2
>::2 3
>::3 4(
GetTotalRatingInstructorById::5 Q
(::Q R
[::R S
	FromRoute::S \
]::\ ]
Guid::^ b
instructorId::c o
)::o p
{;; 	
var<< 
responseDto<< 
=<< 
await<< #
_instructorService<<$ 6
.<<6 7$
GetInstructorTotalRating<<7 O
(<<O P
instructorId<<P \
)<<\ ]
;<<] ^
return== 

StatusCode== 
(== 
responseDto== )
.==) *

StatusCode==* 4
,==4 5
responseDto==6 A
)==A B
;==B C
}>> 	
[@@ 	
HttpGet@@	 
]@@ 
[AA 	
RouteAA	 
(AA 
$strAA 7
)AA7 8
]AA8 9
publicBB 
asyncBB 
TaskBB 
<BB 
ActionResultBB &
<BB& '
ResponseDTOBB' 2
>BB2 3
>BB3 4-
!GetTotalEarnedMoneyInstructorByIdBB5 V
(BBV W
[BBW X
	FromRouteBBX a
]BBa b
GuidBBc g
instructorIdBBh t
)BBt u
{CC 	
varDD 
responseDtoDD 
=DD 
awaitDD #
_instructorServiceDD$ 6
.DD6 7$
GetInstructorEarnedMoneyDD7 O
(DDO P
instructorIdDDP \
)DD\ ]
;DD] ^
returnEE 

StatusCodeEE 
(EE 
responseDtoEE )
.EE) *

StatusCodeEE* 4
,EE4 5
responseDtoEE6 A
)EEA B
;EEB C
}FF 	
[HH 	
HttpGetHH	 
]HH 
[II 	
RouteII	 
(II 
$strII 7
)II7 8
]II8 9
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
ActionResultJJ &
<JJ& '
ResponseDTOJJ' 2
>JJ2 3
>JJ3 4-
!GetTotalPayoutMoneyInstructorByIdJJ5 V
(JJV W
[JJW X
	FromRouteJJX a
]JJa b
GuidJJc g
instructorIdJJh t
)JJt u
{KK 	
varLL 
responseDtoLL 
=LL 
awaitLL #
_instructorServiceLL$ 6
.LL6 7$
GetInstructorPayoutMoneyLL7 O
(LLO P
instructorIdLLP \
)LL\ ]
;LL] ^
returnMM 

StatusCodeMM 
(MM 
responseDtoMM )
.MM) *

StatusCodeMM* 4
,MM4 5
responseDtoMM6 A
)MMA B
;MMB C
}NN 	
[PP 	
HttpPutPP	 
]PP 
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ActionResultQQ &
<QQ& '
ResponseDTOQQ' 2
>QQ2 3
>QQ3 4 
UpdateInstructorByIdQQ5 I
(QQI J
[QQJ K
FromBodyQQK S
]QQS T
UpdateInstructorDTOQQU h
instructorDtoQQi v
)QQv w
{RR 	
varSS 
responseDtoSS 
=SS 
awaitSS #
_instructorServiceSS$ 6
.SS6 7

UpdateByIdSS7 A
(SSA B
instructorDtoSSB O
)SSO P
;SSP Q
returnTT 

StatusCodeTT 
(TT 
responseDtoTT )
.TT) *

StatusCodeTT* 4
,TT4 5
responseDtoTT6 A
)TTA B
;TTB C
}UU 	
[WW 	
HttpPostWW	 
]WW 
[XX 	
RouteXX	 
(XX 
$strXX +
)XX+ ,
]XX, -
publicYY 
asyncYY 
TaskYY 
<YY 
ActionResultYY &
<YY& '
ResponseDTOYY' 2
>YY2 3
>YY3 4
AcceptInstructorYY5 E
(YYE F
[YYF G
	FromRouteYYG P
]YYP Q
GuidYYR V
instructorIdYYW c
)YYc d
{ZZ 	
var[[ 
responseDto[[ 
=[[ 
await[[ #
_instructorService[[$ 6
.[[6 7
AcceptInstructor[[7 G
([[G H
User[[H L
,[[L M
instructorId[[N Z
)[[Z [
;[[[ \
return\\ 

StatusCode\\ 
(\\ 
responseDto\\ )
.\\) *

StatusCode\\* 4
,\\4 5
responseDto\\6 A
)\\A B
;\\B C
}]] 	
[__ 	
HttpPost__	 
]__ 
[`` 	
Route``	 
(`` 
$str`` +
)``+ ,
]``, -
publicaa 
asyncaa 
Taskaa 
<aa 
ActionResultaa &
<aa& '
ResponseDTOaa' 2
>aa2 3
>aa3 4
RejectInstructoraa5 E
(aaE F
[aaF G
	FromRouteaaG P
]aaP Q
GuidaaR V
instructorIdaaW c
)aac d
{bb 	
varcc 
responseDtocc 
=cc 
awaitcc #
_instructorServicecc$ 6
.cc6 7
RejectInstructorcc7 G
(ccG H
UserccH L
,ccL M
instructorIdccN Z
)ccZ [
;cc[ \
returndd 

StatusCodedd 
(dd 
responseDtodd )
.dd) *

StatusCodedd* 4
,dd4 5
responseDtodd6 A
)ddA B
;ddB C
}ee 	
[jj 	
HttpGetjj	 
]jj 
[kk 	
Routekk	 
(kk 
$strkk ,
)kk, -
]kk- .
publicll 
asyncll 
Taskll 
<ll 
ActionResultll &
<ll& '
ResponseDTOll' 2
>ll2 3
>ll3 4#
GetAllInstructorCommentll5 L
(mm 	
[nn 
	FromRoutenn 
]nn 
Guidnn 
instructorIdnn )
,nn) *
[oo 
	FromQueryoo 
]oo 
intoo 

pageNumberoo &
=oo' (
$numoo) *
,oo* +
[pp 
	FromQuerypp 
]pp 
intpp 
pageSizepp $
=pp% &
$numpp' )
)qq 	
{rr 	
varss 
responseDtoss 
=ss 
awaitss #
_instructorServicess$ 6
.ss6 7#
GetAllInstructorCommentss7 N
(ssN O
instructorIdssO [
,ss[ \

pageNumberss] g
,ssg h
pageSizessi q
)ssq r
;ssr s
returntt 

StatusCodett 
(tt 
responseDtott )
.tt) *

StatusCodett* 4
,tt4 5
responseDtott6 A
)ttA B
;ttB C
}uu 	
[ww 	
HttpPostww	 
]ww 
[xx 	
Routexx	 
(xx 
$strxx 
)xx 
]xx 
publicyy 
asyncyy 
Taskyy 
<yy 
ActionResultyy &
<yy& '
ResponseDTOyy' 2
>yy2 3
>yy3 4#
CreateInstructorCommentyy5 L
(zz 	&
CreateInstructorCommentDTO{{ &#
createInstructorComment{{' >
){{> ?
{|| 	
var}} 
responseDto}} 
=}} 
await}} #
_instructorService}}$ 6
.}}6 7#
CreateInstructorComment}}7 N
(}}N O
User}}O S
,}}S T#
createInstructorComment}}U l
)}}l m
;}}m n
return~~ 

StatusCode~~ 
(~~ 
responseDto~~ )
.~~) *

StatusCode~~* 4
,~~4 5
responseDto~~6 A
)~~A B
;~~B C
} 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4%
UpdateInstructorComment
��5 L
(
�� 	(
UpdateInstructorCommentDTO
�� &%
updateInstructorComment
��' >
)
��> ?
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� # 
_instructorService
��$ 6
.
��6 7%
UpdateInstructorComment
��7 N
(
��N O
User
��O S
,
��S T%
updateInstructorComment
��U l
)
��l m
;
��m n
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4%
DeleteInstructorComment
��5 L
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
	commentId
�� &
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� # 
_instructorService
��$ 6
.
��6 7%
DeleteInstructorComment
��7 N
(
��N O
	commentId
��O X
)
��X Y
;
��Y Z
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� .
)
��. /
]
��/ 0
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
ExportInstructor
��5 E
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
int
�� 
month
�� !
,
��! "
[
�� 
	FromRoute
�� 
]
�� 
int
�� 
year
��  
)
�� 	
{
�� 	
var
�� 
userId
�� 
=
�� 
User
�� 
.
�� 
Claims
�� $
.
��$ %
FirstOrDefault
��% 3
(
��3 4
x
��4 5
=>
��6 8
x
��9 :
.
��: ;
Type
��; ?
==
��@ B

ClaimTypes
��C M
.
��M N
NameIdentifier
��N \
)
��\ ]
?
��] ^
.
��^ _
Value
��_ d
;
��d e
BackgroundJob
�� 
.
�� 
Enqueue
�� !
<
��! " 
IInstructorService
��" 4
>
��4 5
(
��5 6
job
��6 9
=>
��: <
job
��= @
.
��@ A
ExportInstructors
��A R
(
��R S
userId
��S Y
,
��Y Z
month
��[ `
,
��` a
year
��b f
)
��f g
)
��g h
;
��h i
return
�� 
Ok
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� $
)
��$ %
]
��% &
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '"
ClosedXMLResponseDTO
��' ;
>
��; <
>
��< = 
DownloadInstructor
��> P
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
string
�� 
fileName
�� '
)
�� 	
{
�� 	
var
�� "
closedXmlResponseDto
�� $
=
��% &
await
��' , 
_instructorService
��- ?
.
��? @!
DownloadInstructors
��@ S
(
��S T
fileName
��T \
)
��\ ]
;
��] ^
var
�� 
stream
�� 
=
�� "
closedXmlResponseDto
�� -
.
��- .
Stream
��. 4
;
��4 5
var
�� 
contentType
�� 
=
�� "
closedXmlResponseDto
�� 2
.
��2 3
ContentType
��3 >
;
��> ?
if
�� 
(
�� 
stream
�� 
is
�� 
null
�� 
||
�� !
contentType
��" -
is
��. 0
null
��1 5
)
��5 6
{
�� 
return
�� 
NotFound
�� 
(
��  
)
��  !
;
��! "
}
�� 
return
�� 
File
�� 
(
�� 
stream
�� 
,
�� 
contentType
��  +
,
��+ ,
fileName
��- 5
)
��5 6
;
��6 7
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4'
GetTopInstructorsByPayout
��5 N
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
topN
��  
,
��  !
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 

filterYear
�� '
,
��' (
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
filterMonth
�� (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
filterQuarter
�� *
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_paymentService
��$ 3
.
��3 4'
GetTopInstructorsByPayout
��4 M
(
�� 
topN
�� 
,
�� 

filterYear
�� 
,
�� 
filterMonth
�� 
,
�� 
filterQuarter
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4)
GetLeastInstructorsByPayout
��5 P
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
topN
��  
,
��  !
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 

filterYear
�� '
,
��' (
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
filterMonth
�� (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
filterQuarter
�� *
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_paymentService
��$ 3
.
��3 4)
GetLeastInstructorsByPayout
��4 O
(
�� 
topN
�� 
,
�� 

filterYear
�� 
,
�� 
filterMonth
�� 
,
�� 
filterQuarter
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
}
�� 
}�� ϯ
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
$strBB 
)BB 
]BB 
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
$strNN 
)NN 
]NN 
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
$strZZ 
)ZZ 
]ZZ 
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
$strdd '
)dd' (
]dd( )
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
$strll '
)ll' (
]ll( )
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
$strtt '
)tt' (
]tt( )
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
$str|| '
)||' (
]||( )
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
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� &
)
��& '
]
��' (
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
MergeCourseVersion
��5 G
(
��G H
[
��H I
	FromRoute
��I R
]
��R S
Guid
��T X
courseId
��Y a
)
��a b
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� ##
_courseVersionService
��$ 9
.
��9 : 
MergeCourseVersion
��: L
(
��L M
User
��M Q
,
��Q R
courseId
��S [
)
��[ \
;
��\ ]
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 2
)
��2 3
]
��3 4
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4+
UploadCourseVersionBackground
��5 R
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
courseVersionId
�� ,
,
��, -.
 UploadCourseVersionBackgroundImg
�� ,.
 uploadCourseVersionBackgroundImg
��- M
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseVersionService
�� +
.
��+ ,.
 UploadCourseVersionBackgroundImg
��, L
(
�� 
User
�� 
,
�� 
courseVersionId
�� #
,
��# $.
 uploadCourseVersionBackgroundImg
�� 4
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 2
)
��2 3
]
��3 4
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
>
��& ',
DisplayCourseVersionBackground
��( F
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
courseVersionId
�� ,
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� ##
_courseVersionService
��$ 9
.
��9 :/
!DisplayCourseVersionBackgroundImg
��: [
(
��[ \
User
��\ `
,
��` a
courseVersionId
��b q
)
��q r
;
��r s
if
�� 
(
�� 
responseDto
�� 
is
�� 
null
�� #
)
��# $
{
�� 
return
�� 
null
�� 
;
�� 
}
�� 
return
�� 
File
�� 
(
�� 
responseDto
�� #
,
��# $
$str
��% 0
)
��0 1
;
��1 2
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4'
GetCourseVersionsComments
��5 N
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
[
�� 
Required
�� !
]
��! "
Guid
��# '
courseVersionId
��( 7
,
��7 8
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterOn
��  (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterQuery
��  +
,
��+ ,
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
sortBy
��  &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
=
��' (
$num
��) *
,
��* +
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
=
��% &
$num
��' )
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� ##
_courseVersionService
��$ 9
.
��9 :'
GetCourseVersionsComments
��: S
(
�� 
User
�� 
,
�� 
courseVersionId
�� 
,
��  
filterOn
�� 
,
�� 
filterQuery
�� 
,
�� 
sortBy
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4%
GetCourseVersionComment
��5 L
(
��L M
[
��M N
	FromRoute
��N W
]
��W X
Guid
��Y ]
	commentId
��^ g
)
��g h
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� ##
_courseVersionService
��$ 9
.
��9 :%
GetCourseVersionComment
��: Q
(
��Q R
User
��R V
,
��V W
	commentId
��X a
)
��a b
;
��b c
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4(
CreateCourseVersionComment
��5 O
(
�� 	,
CreateCourseVersionCommentsDTO
�� *,
createCourseVersionCommentsDto
��+ I
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseVersionService
�� +
.
��+ ,(
CreateCourseVersionComment
��, F
(
��F G
User
��G K
,
��K L,
createCourseVersionCommentsDto
��M k
)
��k l
;
��l m
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4&
EditCourseVersionComment
��5 M
(
�� 	*
EditCourseVersionCommentsDTO
�� (*
editCourseVersionCommentsDto
��) E
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� ##
_courseVersionService
��$ 9
.
��9 :&
EditCourseVersionComment
��: R
(
��R S
User
��S W
,
��W X*
editCourseVersionCommentsDto
��Y u
)
��u v
;
��v w
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4(
RemoveCourseVersionComment
��5 O
(
��O P
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
	commentId
�� &
)
��& '
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseVersionService
�� +
.
��+ ,(
RemoveCourseVersionComment
��, F
(
��F G
User
��G K
,
��K L
	commentId
��M V
)
��V W
;
��W X
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
GetCourseSections
��5 F
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
[
�� 
Required
�� !
]
��! "
Guid
��# '
?
��' (
courseVersionId
��) 8
,
��8 9
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterOn
��  (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterQuery
��  +
,
��+ ,
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
sortBy
��  &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
bool
�� 
?
�� 
isAscending
�� )
,
��) *
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
=
��' (
$num
��) *
,
��* +
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
=
��% &
$num
��' (
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #*
_courseSectionVersionService
��$ @
.
��@ A
GetCourseSections
��A R
(
�� 
User
�� 
,
�� 
courseVersionId
�� 
,
��  
filterOn
�� 
,
�� 
filterQuery
�� 
,
�� 
sortBy
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
GetCourseSection
��5 E
(
��E F
[
��F G
	FromRoute
��G P
]
��P Q
Guid
��R V
	sectionId
��W `
)
��` a
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #*
_courseSectionVersionService
��$ @
.
��@ A
GetCourseSection
��A Q
(
��Q R
User
��R V
,
��V W
	sectionId
��X a
)
��a b
;
��b c
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +

Instructor
��+ 5
)
��5 6
]
��6 7
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4!
CreateCourseSection
��5 H
(
�� 	+
CreateCourseSectionVersionDTO
�� )+
createCourseSectionVersionDto
��* G
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� *
_courseSectionVersionService
�� 2
.
��2 3!
CreateCourseSection
��3 F
(
��F G
User
��G K
,
��K L+
createCourseSectionVersionDto
��M j
)
��j k
;
��k l
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
EditCourseSection
��5 F
(
�� 	)
EditCourseSectionVersionDTO
�� '+
createCourseSectionVersionDto
��( E
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #*
_courseSectionVersionService
��$ @
.
��@ A
EditCourseSection
��A R
(
��R S
User
��S W
,
��W X+
createCourseSectionVersionDto
��Y v
)
��v w
;
��w x
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� $
)
��$ %
]
��% &
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4!
DeleteCourseSection
��5 H
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
	sectionId
�� &
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� *
_courseSectionVersionService
�� 2
.
��2 3!
RemoveCourseSection
��3 F
(
��F G
User
��G K
,
��K L
	sectionId
��M V
)
��V W
;
��W X
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4(
GetSectionsDetailsVersions
��5 O
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
Guid
�� 
?
�� 
courseSectionId
�� -
,
��- .
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterOn
��  (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterQuery
��  +
,
��+ ,
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
sortBy
��  &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
bool
�� 
?
�� 
isAscending
�� )
,
��) *
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
=
��' (
$num
��) *
,
��* +
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
=
��% &
$num
��' (
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #+
_sectionDetailsVersionService
��$ A
.
��A B(
GetSectionsDetailsVersions
��B \
(
�� 
User
�� 
,
�� 
courseSectionId
�� 
,
��  
filterOn
�� 
,
�� 
filterQuery
�� 
,
�� 
sortBy
�� 
,
�� 
isAscending
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 1
)
��1 2
]
��2 3
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4'
GetSectionsDetailsVersion
��5 N
(
��N O
[
��O P
	FromRoute
��P Y
]
��Y Z
Guid
��[ _
	detailsId
��` i
)
��i j
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #+
_sectionDetailsVersionService
��$ A
.
��A B&
GetSectionDetailsVersion
��B Z
(
��Z [
User
��[ _
,
��_ `
	detailsId
��a j
)
��j k
;
��k l
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +

Instructor
��+ 5
)
��5 6
]
��6 7
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4)
CreateSectionDetailsVersion
��5 P
(
��P Q
[
�� 
FromBody
�� 
]
�� ,
CreateSectionDetailsVersionDTO
�� 5,
createSectionDetailsVersionDto
��6 T
)
��T U
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� +
_sectionDetailsVersionService
�� 3
.
��3 4)
CreateSectionDetailsVersion
��4 O
(
��O P
User
��P T
,
��T U,
createSectionDetailsVersionDto
��V t
)
��t u
;
��u v
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4'
EditSectionDetailsVersion
��5 N
(
��N O
[
�� 
FromBody
�� 
]
�� *
EditSectionDetailsVersionDTO
�� 3*
editSectionDetailsVersionDto
��4 P
)
��P Q
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� +
_sectionDetailsVersionService
�� 3
.
��3 4'
EditSectionDetailsVersion
��4 M
(
��M N
User
��N R
,
��R S*
editSectionDetailsVersionDto
��T p
)
��p q
;
��q r
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 1
)
��1 2
]
��2 3
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4)
RemoveSectionDetailsVersion
��5 P
(
��P Q
[
��Q R
	FromRoute
��R [
]
��[ \
Guid
��] a
	detailsId
��b k
)
��k l
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� +
_sectionDetailsVersionService
�� 3
.
��3 4)
RemoveSectionDetailsVersion
��4 O
(
��O P
User
��P T
,
��T U
	detailsId
��V _
)
��_ `
;
��` a
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 9
)
��9 :
]
��: ;
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 40
"UploadSectionDetailsVersionContent
��5 W
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
	detailsId
�� &
,
��& '3
%UploadSectionDetailsVersionContentDTO
�� 13
%uploadSectionDetailsVersionContentDto
��2 W
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� +
_sectionDetailsVersionService
�� 3
.
��3 40
"UploadSectionDetailsVersionContent
��4 V
(
�� 
User
�� 
,
�� 
	detailsId
�� 
,
�� 3
%uploadSectionDetailsVersionContentDto
�� 9
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (1
#DisplaySectionDetailsVersionContent
��) L
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
Guid
�� %
sectionDetailsVersionId
�� 4
,
��4 5
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
type
�� #
)
�� 	
{
�� 	
var
��  
contentResponseDto
�� "
=
��# $
await
�� +
_sectionDetailsVersionService
�� 3
.
��3 41
#DisplaySectionDetailsVersionContent
��4 W
(
�� 
User
�� 
,
�� %
sectionDetailsVersionId
�� +
,
��+ ,
type
�� 
)
�� 
;
�� 
if
�� 
(
��  
contentResponseDto
�� "
.
��" #
Stream
��# )
is
��* ,
null
��- 1
)
��1 2
{
�� 
return
�� 
NotFound
�� 
(
��  
$str
��  7
)
��7 8
;
��8 9
}
�� 
if
�� 
(
��  
contentResponseDto
�� "
.
��" #
ContentType
��# .
==
��/ 1"
StaticFileExtensions
��2 F
.
��F G
Mov
��G J
||
��K M 
contentResponseDto
�� "
.
��" #
ContentType
��# .
==
��/ 1"
StaticFileExtensions
��2 F
.
��F G
Mp4
��G J
)
��J K
{
�� 
return
�� 
File
�� 
(
��  
contentResponseDto
�� .
.
��. /
Stream
��/ 5
,
��5 6 
contentResponseDto
��7 I
.
��I J
ContentType
��J U
)
��U V
;
��V W
}
�� 
return
�� 
File
�� 
(
��  
contentResponseDto
�� *
.
��* +
Stream
��+ 1
,
��1 2 
contentResponseDto
��3 E
.
��E F
ContentType
��F Q
,
��Q R 
contentResponseDto
��S e
.
��e f
FileName
��f n
)
��n o
;
��o p
}
�� 	
}
�� 
}�� ��
iD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CourseController.cs
	namespace

 	
Cursus


 
.

 
LMS

 
.

 
API

 
.

 
Controllers

 $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CourseController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
ICourseService '
_courseService( 6
;6 7
private 
readonly  
ICourseReviewService - 
_courseReviewService. B
;B C
private 
readonly  
ICourseReportService - 
_courseReportService. B
;B C
public 
CourseController 
( 	
ICourseService 
courseService (
,( ) 
ICourseReviewService  
courseReviewService! 4
,4 5 
ICourseReportService  
courseReportService! 4
) 	
{ 	
_courseService 
= 
courseService *
;* + 
_courseReviewService  
=! "
courseReviewService# 6
;6 7 
_courseReportService  
=! "
courseReportService# 6
;6 7
} 	
[!! 	
HttpGet!!	 
]!! 
public"" 
async"" 
Task"" 
<"" 
ActionResult"" &
<""& '
ResponseDTO""' 2
>""2 3
>""3 4

GetCourses""5 ?
(## 	
[$$ 
	FromQuery$$ 
]$$ 
Guid$$ 
?$$ 
instructorId$$ *
,$$* +
[%% 
	FromQuery%% 
]%% 
string%% 
?%% 
filterOn%%  (
,%%( )
[&& 
	FromQuery&& 
]&& 
string&& 
?&& 
filterQuery&&  +
,&&+ ,
['' 
	FromQuery'' 
]'' 
string'' 
?'' 
sortBy''  &
,''& '
[(( 
	FromQuery(( 
](( 
bool(( 
?(( 
isAscending(( )
,(() *
[)) 
	FromQuery)) 
])) 
double)) 
?)) 
	fromPrice))  )
,))) *
[** 
	FromQuery** 
]** 
double** 
?** 
toPrice**  '
,**' (
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
await// #
_courseService//$ 2
.//2 3

GetCourses//3 =
(00 
User11 
,11 
instructorId22 
,22 
filterOn33 
,33 
filterQuery44 
,44 
	fromPrice55 
,55 
toPrice66 
,66 
sortBy77 
,77 
isAscending88 
,88 

pageNumber99 
,99 
pageSize:: 
);; 
;;; 
return<< 

StatusCode<< 
(<< 
responseDto<< )
.<<) *

StatusCode<<* 4
,<<4 5
responseDto<<6 A
)<<A B
;<<B C
}== 	
[?? 	
HttpGet??	 
]?? 
[@@ 	
Route@@	 
(@@ 
$str@@  
)@@  !
]@@! "
publicAA 
asyncAA 
TaskAA 
<AA 
ActionResultAA &
<AA& '
ResponseDTOAA' 2
>AA2 3
>AA3 4
	GetCourseAA5 >
(AA> ?
[AA? @
	FromRouteAA@ I
]AAI J
GuidAAK O
courseIdAAP X
)AAX Y
{BB 	
varCC 
responseDtoCC 
=CC 
awaitCC #
_courseServiceCC$ 2
.CC2 3
	GetCourseCC3 <
(CC< =
UserCC= A
,CCA B
courseIdCCC K
)CCK L
;CCL M
returnDD 

StatusCodeDD 
(DD 
responseDtoDD )
.DD) *

StatusCodeDD* 4
,DD4 5
responseDtoDD6 A
)DDA B
;DDB C
}EE 	
[GG 	
HttpPostGG	 
]GG 
[HH 	
RouteHH	 
(HH 
$strHH )
)HH) *
]HH* +
[II 	
	AuthorizeII	 
(II 
RolesII 
=II 
StaticUserRolesII *
.II* +
AdminInstructorII+ :
)II: ;
]II; <
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
ActionResultJJ &
<JJ& '
ResponseDTOJJ' 2
>JJ2 3
>JJ3 4
ActivateCourseJJ5 C
(JJC D
[JJD E
	FromRouteJJE N
]JJN O
GuidJJP T
courseIdJJU ]
)JJ] ^
{KK 	
varLL 
responseDtoLL 
=LL 
awaitLL #
_courseServiceLL$ 2
.LL2 3
ActivateCourseLL3 A
(LLA B
UserLLB F
,LLF G
courseIdLLH P
)LLP Q
;LLQ R
returnMM 

StatusCodeMM 
(MM 
responseDtoMM )
.MM) *

StatusCodeMM* 4
,MM4 5
responseDtoMM6 A
)MMA B
;MMB C
}NN 	
[PP 	
HttpPostPP	 
]PP 
[QQ 	
RouteQQ	 
(QQ 
$strQQ +
)QQ+ ,
]QQ, -
[RR 	
	AuthorizeRR	 
(RR 
RolesRR 
=RR 
StaticUserRolesRR *
.RR* +
AdminInstructorRR+ :
)RR: ;
]RR; <
publicSS 
asyncSS 
TaskSS 
<SS 
ActionResultSS &
<SS& '
ResponseDTOSS' 2
>SS2 3
>SS3 4
DeactivateCourseSS5 E
(SSE F
[SSF G
	FromRouteSSG P
]SSP Q
GuidSSR V
courseIdSSW _
)SS_ `
{TT 	
varUU 
responseDtoUU 
=UU 
awaitUU #
_courseServiceUU$ 2
.UU2 3
DeactivateCourseUU3 C
(UUC D
UserUUD H
,UUH I
courseIdUUJ R
)UUR S
;UUS T
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
[ZZ 	
HttpGetZZ	 
]ZZ 
[[[ 	
Route[[	 
([[ 
$str[[ 
)[[ 
][[ 
[\\ 	
	Authorize\\	 
]\\ 
public]] 
async]] 
Task]] 
<]] 
ActionResult]] &
<]]& '
ResponseDTO]]' 2
>]]2 3
>]]3 4
GetCourseReviews]]5 E
(^^ 	
[__ 
	FromQuery__ 
]__ 
Guid__ 
?__ 
courseId__ &
,__& '
[`` 
	FromQuery`` 
]`` 
string`` 
?`` 
filterOn``  (
,``( )
[aa 
	FromQueryaa 
]aa 
stringaa 
?aa 
filterQueryaa  +
,aa+ ,
[bb 
	FromQuerybb 
]bb 
stringbb 
?bb 
sortBybb  &
,bb& '
[cc 
	FromQuerycc 
]cc 
boolcc 
?cc 
isAscendingcc )
,cc) *
[dd 
	FromQuerydd 
]dd 
intdd 

pageNumberdd &
=dd' (
$numdd) *
,dd* +
[ee 
	FromQueryee 
]ee 
intee 
pageSizeee $
=ee% &
$numee' (
)ff 	
{gg 	
varhh 
responseDtohh 
=hh 
awaithh # 
_courseReviewServicehh$ 8
.hh8 9
GetCourseReviewshh9 I
(hhI J
Userii 
,ii 
courseIdjj 
,jj 
filterOnkk 
,kk 
filterQueryll 
,ll 
sortBymm 
,mm 
isAscendingnn 
,nn 

pageNumberoo 
,oo 
pageSizepp 
)qq 
;qq 
returnss 

StatusCodess 
(ss 
responseDtoss )
.ss) *

StatusCodess* 4
,ss4 5
responseDtoss6 A
)ssA B
;ssB C
}tt 	
[vv 	
HttpGetvv	 
]vv 
[ww 	
Routeww	 
(ww 
$strww '
)ww' (
]ww( )
[xx 	
	Authorizexx	 
]xx 
publicyy 
asyncyy 
Taskyy 
<yy 
ActionResultyy &
<yy& '
ResponseDTOyy' 2
>yy2 3
>yy3 4
GetCourseReviewyy5 D
(yyD E
[yyE F
	FromRouteyyF O
]yyO P
GuidyyQ U
reviewIdyyV ^
)yy^ _
{zz 	
try{{ 
{|| 
var}} 
responseDto}} 
=}}  !
await}}" ' 
_courseReviewService}}( <
.}}< =
GetCourseReviewById}}= P
(}}P Q
reviewId}}Q Y
)}}Y Z
;}}Z [
return~~ 

StatusCode~~ !
(~~! "
responseDto~~" -
.~~- .

StatusCode~~. 8
,~~8 9
responseDto~~: E
)~~E F
;~~F G
} 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Student
��+ 2
)
��2 3
]
��3 4
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
CreateCourseReview
��5 G
(
��G H
[
�� 
FromBody
�� 
]
�� #
CreateCourseReviewDTO
�� ,#
createCourseReviewDto
��- B
)
��B C
{
�� 	
if
�� 
(
�� 
!
�� 

ModelState
�� 
.
�� 
IsValid
�� #
)
��# $
{
�� 
return
�� 

BadRequest
�� !
(
��! "
new
��" %
ResponseDTO
��& 1
{
�� 
Message
�� 
=
�� 
$str
�� ,
,
��, -
Result
�� 
=
�� 

ModelState
�� '
,
��' (
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReviewService
��( <
.
��< = 
CreateCourseReview
��= O
(
��O P#
createCourseReviewDto
��P e
)
��e f
;
��f g
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
UpdateCourseReview
��5 G
(
��G H
[
�� 
FromBody
�� 
]
�� #
UpdateCourseReviewDTO
�� ,#
updateCourseReviewDto
��- B
)
��B C
{
�� 	
if
�� 
(
�� 
!
�� 

ModelState
�� 
.
�� 
IsValid
�� #
)
��# $
{
�� 
return
�� 

BadRequest
�� !
(
��! "
new
��" %
ResponseDTO
��& 1
{
�� 
Message
�� 
=
�� 
$str
�� ,
,
��, -
Result
�� 
=
�� 

ModelState
�� '
,
��' (
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReviewService
��( <
.
��< = 
UpdateCourseReview
��= O
(
��O P
User
��P T
,
��T U#
updateCourseReviewDto
��V k
)
��k l
;
��l m
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� '
)
��' (
]
��( )
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
DeleteCourseReview
��5 G
(
��G H
[
��H I
	FromRoute
��I R
]
��R S
Guid
��T X
reviewId
��Y a
)
��a b
{
�� 	
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReviewService
��( <
.
��< = 
DeleteCourseReview
��= O
(
��O P
reviewId
��P X
)
��X Y
;
��Y Z
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� ,
)
��, -
]
��- .
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +

Instructor
��+ 5
)
��5 6
]
��6 7
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
MarkCourseReview
��5 E
(
��E F
[
��F G
	FromRoute
��G P
]
��P Q
Guid
��R V
reviewId
��W _
)
��_ `
{
�� 	
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReviewService
��( <
.
��< =
MarkCourseReview
��= M
(
��M N
reviewId
��N V
)
��V W
;
��W X
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
GetCourseReports
��5 E
(
��E F
[
�� 
	FromQuery
�� 
]
�� 
Guid
�� 
?
�� 
courseId
�� &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterOn
��  (
,
��( )
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
filterQuery
��  +
,
��+ ,
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
sortBy
��  &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
bool
�� 
?
�� 
isAscending
�� )
,
��) *
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
=
��' (
$num
��) *
,
��* +
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
=
��% &
$num
��' (
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #"
_courseReportService
��$ 8
.
��8 9
GetCourseReports
��9 I
(
��I J
User
�� 
,
�� 
courseId
�� 
,
�� 
filterOn
�� 
,
�� 
filterQuery
�� 
,
�� 
sortBy
�� 
,
�� 
isAscending
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� '
)
��' (
]
��( )
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
GetCourseReport
��5 D
(
��D E
[
��E F
	FromRoute
��F O
]
��O P
Guid
��Q U
reportId
��V ^
)
��^ _
{
�� 	
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReportService
��( <
.
��< =!
GetCourseReportById
��= P
(
��P Q
reportId
��Q Y
)
��Y Z
;
��Z [
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Student
��+ 2
)
��2 3
]
��3 4
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
CreateCourseReport
��5 G
(
��G H
[
�� 
FromBody
�� 
]
�� #
CreateCourseReportDTO
�� ,#
createCourseReportDTO
��- B
)
��B C
{
�� 	
if
�� 
(
�� 
!
�� 

ModelState
�� 
.
�� 
IsValid
�� #
)
��# $
{
�� 
return
�� 

BadRequest
�� !
(
��! "
new
��" %
ResponseDTO
��& 1
{
�� 
Message
�� 
=
�� 
$str
�� ,
,
��, -
Result
�� 
=
�� 

ModelState
�� '
,
��' (
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReportService
��( <
.
��< = 
CreateCourseReport
��= O
(
��O P#
createCourseReportDTO
��P e
)
��e f
;
��f g
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
UpdateCourseReport
��5 G
(
��G H
[
�� 
FromBody
�� 
]
�� #
UpdateCourseReportDTO
�� ,#
updateCourseReportDTO
��- B
)
��B C
{
�� 	
if
�� 
(
�� 
!
�� 

ModelState
�� 
.
�� 
IsValid
�� #
)
��# $
{
�� 
return
�� 

BadRequest
�� !
(
��! "
new
��" %
ResponseDTO
��& 1
{
�� 
Message
�� 
=
�� 
$str
�� ,
,
��, -
Result
�� 
=
�� 

ModelState
�� '
,
��' (
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReportService
��( <
.
��< = 
UpdateCourseReport
��= O
(
��O P
User
��P T
,
��T U#
updateCourseReportDTO
��V k
)
��k l
;
��l m
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� '
)
��' (
]
��( )
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4 
DeleteCourseReport
��5 G
(
��G H
[
��H I
	FromRoute
��I R
]
��R S
Guid
��T X
reportId
��Y a
)
��a b
{
�� 	
try
�� 
{
�� 
var
�� 
responseDto
�� 
=
��  !
await
��" '"
_courseReportService
��( <
.
��< = 
DeleteCourseReport
��= O
(
��O P
reportId
��P X
)
��X Y
;
��Y Z
return
�� 

StatusCode
�� !
(
��! "
responseDto
��" -
.
��- .

StatusCode
��. 8
,
��8 9
responseDto
��: E
)
��E F
;
��F G
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
return
�� 

StatusCode
�� !
(
��! "
$num
��" %
,
��% &
new
��' *
ResponseDTO
��+ 6
{
�� 
Message
�� 
=
�� 
ex
��  
.
��  !
Message
��! (
,
��( )
Result
�� 
=
�� 
null
�� !
,
��! "
	IsSuccess
�� 
=
�� 
false
��  %
,
��% &

StatusCode
�� 
=
��  
$num
��! $
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
��  
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4$
GetTopPurchasedCourses
��5 K
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
year
�� !
,
��! "
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
month
�� "
,
��" #
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
quarter
�� $
,
��$ %
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
top
�� 
,
��  
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
,
��$ %
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
byCategoryName
��  .
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseService
��$ 2
.
��2 3$
GetTopPurchasedCourses
��3 I
(
�� 
year
�� 
,
�� 
month
�� 
,
�� 
quarter
�� 
,
�� 
top
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
,
�� 
byCategoryName
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4&
GetLeastPurchasedCourses
��5 M
(
�� 	
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
year
�� !
,
��! "
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
month
�� "
,
��" #
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
?
�� 
quarter
�� $
,
��$ %
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
top
�� 
,
��  
[
�� 
	FromQuery
�� 
]
�� 
int
�� 

pageNumber
�� &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
int
�� 
pageSize
�� $
,
��$ %
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
?
�� 
byCategoryName
��  .
)
�� 	
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseService
��$ 2
.
��2 3&
GetLeastPurchasedCourses
��3 K
(
�� 
year
�� 
,
�� 
month
�� 
,
�� 
quarter
�� 
,
�� 
top
�� 
,
�� 

pageNumber
�� 
,
�� 
pageSize
�� 
,
�� 
byCategoryName
�� 
)
�� 
;
�� 
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
(
�� 
Roles
�� 
=
�� 
StaticUserRoles
�� *
.
��* +
Admin
��+ 0
)
��0 1
]
��1 2
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
EnrollCourse
��5 A
(
��A B
[
��B C
FromBody
��C K
]
��K L
EnrollCourseDTO
��M \
enrollCourseDto
��] l
)
��l m
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_courseService
��$ 2
.
��2 3
EnrollCourse
��3 ?
(
��? @
User
��@ D
,
��D E
enrollCourseDto
��F U
)
��U V
;
��V W
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
>
��& '
SuggestCourses
��( 6
(
��6 7
[
��7 8
	FromRoute
��8 A
]
��A B
Guid
��C G
	studentId
��H Q
)
��Q R
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_courseService
��! /
.
��/ 0
SuggestCourse
��0 =
(
��= >
	studentId
��> G
)
��G H
;
��H I
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	
HttpGet
��	 
(
�� 
$str
�� .
)
��. /
]
��/ 0
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' ()
GetAllBookMarkedCoursesById
��) D
(
�� 	
[
�� 
	FromRoute
�� 
]
�� 
Guid
�� 
	studentId
�� &
,
��& '
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
	sortOrder
�� (
=
��) *
$str
��+ 1
)
�� 	
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_courseService
��! /
.
��/ 0)
GetAllBookMarkedCoursesById
��0 K
(
��K L
	studentId
��L U
,
��U V
	sortOrder
��W `
)
��` a
;
��a b
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
>
��& '$
CreateBookMarkedCourse
��( >
(
��> ?%
CreateCourseBookmarkDTO
��? V%
createCourseBookmarkDto
��W n
)
��n o
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_courseService
��! /
.
��/ 0$
CreateBookMarkedCourse
��0 F
(
��F G
User
��G K
,
��K L%
createCourseBookmarkDto
��M d
)
��d e
;
��e f
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	

HttpDelete
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� /
)
��/ 0
]
��0 1
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
>
��& '$
DeleteBookMarkedCourse
��( >
(
��> ?
[
��? @
	FromRoute
��@ I
]
��I J
Guid
��K O
bookmarkedId
��P \
)
��\ ]
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_courseService
��! /
.
��/ 0$
DeleteBookMarkedCourse
��0 F
(
��F G
bookmarkedId
��G S
)
��S T
;
��T U
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
}
�� 
}�� �L
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
$str55 
)55 
]55  
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
$str== !
)==! "
]==" #
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
}dd �"
gD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CartController.cs
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
 
[ 
	Authorize 
( 
Roles 
= 
StaticUserRoles &
.& '
AdminStudent' 3
)3 4
]4 5
public 

class 
CartController 
:  !
ControllerBase" 0
{ 
private 
readonly 
ICartService %
_cartService& 2
;2 3
public 
CartController 
( 
ICartService *
cartService+ 6
)6 7
{ 	
_cartService 
= 
cartService &
;& '
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
GetCart5 <
(< =
)= >
{ 	
var 
responseDto 
= 
await #
_cartService$ 0
.0 1
GetCart1 8
(8 9
User9 =
)= >
;> ?
return 

StatusCode 
( 
responseDto )
.) *

StatusCode* 4
,4 5
responseDto6 A
)A B
;B C
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
	AddToCart5 >
(> ?
[? @
FromBody@ H
]H I
AddToCartDTOJ V
addToCartDtoW c
)c d
{ 	
var 
responseDto 
= 
await #
_cartService$ 0
.0 1
	AddToCart1 :
(   
User!! 
,!! 
addToCartDto"" 
)## 
;## 
return$$ 

StatusCode$$ 
($$ 
responseDto$$ )
.$$) *

StatusCode$$* 4
,$$4 5
responseDto$$6 A
)$$A B
;$$B C
}%% 	
['' 	

HttpDelete''	 
]'' 
[(( 	
Route((	 
((( 
$str(( )
)(() *
]((* +
public)) 
async)) 
Task)) 
<)) 
ActionResult)) &
<))& '
ResponseDTO))' 2
>))2 3
>))3 4
RemoveFromCart))5 C
())C D
[))D E
	FromRoute))E N
]))N O
Guid))P T
cartDetailsId))U b
)))b c
{** 	
var++ 
responseDto++ 
=++ 
await++ #
_cartService++$ 0
.++0 1
RemoveFromCart++1 ?
(,, 
User-- 
,-- 
cartDetailsId.. 
)// 
;// 
return00 

StatusCode00 
(00 
responseDto00 )
.00) *

StatusCode00* 4
,004 5
responseDto006 A
)00A B
;00B C
}11 	
[33 	
HttpPost33	 
]33 
[44 	
Route44	 
(44 
$str44  
)44  !
]44! "
public55 
async55 
Task55 
<55 
ActionResult55 &
<55& '
ResponseDTO55' 2
>552 3
>553 4
CheckoutWithStripe555 G
(55G H
)55H I
{66 	
var77 
responseDto77 
=77 
await77 #
_cartService77$ 0
.770 1
Checkout771 9
(779 :
User77: >
)77> ?
;77? @
return88 

StatusCode88 
(88 
responseDto88 )
.88) *

StatusCode88* 4
,884 5
responseDto886 A
)88A B
;88B C
}99 	
}:: 
};; �K
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
�� 	
HttpPost
��	 
]
�� 
public
�� 
ActionResult
�� 
<
�� 
ResponseDTO
�� '
>
��' (!
CreateEmailTemplate
��) <
(
��< =$
CreateEmailTemplateDTO
��= S$
createEmailTemplateDTO
��T j
)
��j k
{
�� 	
return
�� 

BadRequest
�� 
(
�� 
new
�� !
ResponseDTO
��" -
{
�� 
	IsSuccess
�� 
=
�� 
false
�� !
,
��! "
Message
�� 
=
�� 
$str
�� B
}
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� ��
gD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\AuthController.cs
	namespace

 	
Cursus


 
.

 
LMS

 
.

 
API

 
.

 
Controllers

 $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IEmailService &
_emailService' 4
;4 5
private 
readonly 
IAuthService %
_authService& 2
;2 3
private 
ResponseDTO 
responseDto '
=( )
new* -
ResponseDTO. 9
(9 :
): ;
;; <
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
AuthController 
( 
IEmailService +
emailService, 8
,8 9
IAuthService: F
authServiceG R
,R S
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
)4 5
{ 	
_emailService 
= 
emailService (
;( )
_authService 
= 
authService &
;& '
_userManager 
= 
userManager &
;& '
} 	
[!! 	
HttpPost!!	 
]!! 
["" 	
Route""	 
("" 
$str""  
)""  !
]""! "
public## 
async## 
Task## 
<## 
ActionResult## &
<##& '
ResponseDTO##' 2
>##2 3
>##3 4
SignUpStudent##5 B
(##B C
[##C D
FromBody##D L
]##L M
RegisterStudentDTO##N `
registerStudentDTO##a s
)##s t
{$$ 	
if%% 
(%% 
!%% 

ModelState%% 
.%% 
IsValid%% #
)%%# $
{&& 
responseDto'' 
.'' 
	IsSuccess'' %
=''& '
false''( -
;''- .
responseDto(( 
.(( 
Message(( #
=(($ %
$str((& ;
;((; <
responseDto)) 
.)) 
Result)) "
=))# $

ModelState))% /
.))/ 0
Values))0 6
.))6 7

SelectMany))7 A
())A B
v))B C
=>))D F
v))G H
.))H I
Errors))I O
.))O P
Select))P V
())V W
e))W X
=>))Y [
e))\ ]
.))] ^
ErrorMessage))^ j
)))j k
)))k l
;))l m
return** 

BadRequest** !
(**! "
responseDto**" -
)**- .
;**. /
}++ 
try-- 
{.. 
var// 
result// 
=// 
await// "
_authService//# /
./// 0
SignUpStudent//0 =
(//= >
registerStudentDTO//> P
)//P Q
;//Q R
if00 
(00 
result00 
.00 
	IsSuccess00 $
)00$ %
{11 
return22 
Ok22 
(22 
result22 $
)22$ %
;22% &
}33 
else44 
{55 
return66 

BadRequest66 %
(66% &
result66& ,
)66, -
;66- .
}77 
}88 
catch99 
(99 
	Exception99 
e99 
)99 
{:: 
responseDto;; 
.;; 
	IsSuccess;; %
=;;& '
false;;( -
;;;- .
responseDto<< 
.<< 
Message<< #
=<<$ %
e<<& '
.<<' (
Message<<( /
;<</ 0
return== 

StatusCode== !
(==! "
StatusCodes==" -
.==- .(
Status500InternalServerError==. J
,==J K
responseDto==L W
)==W X
;==X Y
}>> 
}?? 	
[EE 	
HttpPostEE	 
]EE 
[FF 	
RouteFF	 
(FF 
$strFF #
)FF# $
]FF$ %
publicGG 
asyncGG 
TaskGG 
<GG 
ActionResultGG &
<GG& '
ResponseDTOGG' 2
>GG2 3
>GG3 4
SignUpInstructorGG5 E
(GGE F
[HH 
FromBodyHH 
]HH 
SignUpInstructorDTOHH *
signUpInstructorDtoHH+ >
)HH> ?
{II 	
varJJ 
resultJJ 
=JJ 
awaitJJ 
_authServiceJJ +
.JJ+ ,
SignUpInstructorJJ, <
(JJ< =
signUpInstructorDtoJJ= P
)JJP Q
;JJQ R
returnKK 

StatusCodeKK 
(KK 
resultKK $
.KK$ %

StatusCodeKK% /
,KK/ 0
resultKK1 7
)KK7 8
;KK8 9
}LL 	
[SS 	
HttpPostSS	 
]SS 
[TT 	
RouteTT	 
(TT 
$strTT "
)TT" #
]TT# $
[UU 	
	AuthorizeUU	 
]UU 
publicVV 
asyncVV 
TaskVV 
<VV 
ActionResultVV &
<VV& '
ResponseDTOVV' 2
>VV2 3
>VV3 4"
UploadInstructorDegreeVV5 K
(VVK L
DegreeUploadDTOVVL [
degreeUploadDtoVV\ k
)VVk l
{WW 	
varXX 
responseXX 
=XX 
awaitXX  
_authServiceXX! -
.XX- ."
UploadInstructorDegreeXX. D
(XXD E
degreeUploadDtoXXE T
.XXT U
FileXXU Y
,XXY Z
UserXX[ _
)XX_ `
;XX` a
returnYY 

StatusCodeYY 
(YY 
responseYY &
.YY& '

StatusCodeYY' 1
,YY1 2
responseYY3 ;
)YY; <
;YY< =
}ZZ 	
[`` 	
HttpGet``	 
]`` 
[aa 	
Routeaa	 
(aa 
$straa "
)aa" #
]aa# $
[bb 	
	Authorizebb	 
]bb 
publiccc 
asynccc 
Taskcc 
<cc 
IActionResultcc '
>cc' (
GetInstructorDegreecc) <
(cc< =
[cc= >
	FromQuerycc> G
]ccG H
boolccI M
DownloadccN V
=ccW X
falseccY ^
)cc^ _
{dd 	
varee 
degreeResponseDtoee !
=ee" #
awaitee$ )
_authServiceee* 6
.ee6 7
GetInstructorDegreeee7 J
(eeJ K
UsereeK O
)eeO P
;eeP Q
ifff 
(ff 
degreeResponseDtoff !
.ff! "
Streamff" (
isff) +
nullff, 0
)ff0 1
{gg 
returnhh 
NotFoundhh 
(hh  
$strhh  =
)hh= >
;hh> ?
}ii 
ifkk 
(kk 
Downloadkk 
)kk 
{ll 
returnmm 
Filemm 
(mm 
degreeResponseDtomm -
.mm- .
Streammm. 4
,mm4 5
degreeResponseDtomm6 G
.mmG H
ContentTypemmH S
,mmS T
degreeResponseDtommU f
.mmf g
FileNamemmg o
)mmo p
;mmp q
}nn 
returnpp 
Filepp 
(pp 
degreeResponseDtopp )
.pp) *
Streampp* 0
,pp0 1
degreeResponseDtopp2 C
.ppC D
ContentTypeppD O
)ppO P
;ppP Q
}qq 	
[yy 	
HttpGetyy	 
]yy 
[zz 	
Routezz	 
(zz 
$strzz 3
)zz3 4
]zz4 5
public{{ 
async{{ 
Task{{ 
<{{ 
IActionResult{{ '
>{{' (#
DisplayInstructorDegree{{) @
({{@ A
[{{A B
	FromRoute{{B K
]{{K L
string{{M S
userId{{T Z
,{{Z [
[|| 
	FromQuery|| 
]|| 
bool|| 
Download|| %
=||& '
false||( -
)||- .
{}} 	
var~~ 
degreeResponseDto~~ !
=~~" #
await~~$ )
_authService~~* 6
.~~6 7#
DisplayInstructorDegree~~7 N
(~~N O
userId~~O U
)~~U V
;~~V W
if 
( 
degreeResponseDto !
.! "
Stream" (
is) +
null, 0
)0 1
{
�� 
return
�� 
NotFound
�� 
(
��  
$str
��  =
)
��= >
;
��> ?
}
�� 
if
�� 
(
�� 
Download
�� 
)
�� 
{
�� 
return
�� 
File
�� 
(
�� 
degreeResponseDto
�� -
.
��- .
Stream
��. 4
,
��4 5
degreeResponseDto
��6 G
.
��G H
ContentType
��H S
,
��S T
degreeResponseDto
��U f
.
��f g
FileName
��g o
)
��o p
;
��p q
}
�� 
return
�� 
File
�� 
(
�� 
degreeResponseDto
�� )
.
��) *
Stream
��* 0
,
��0 1
degreeResponseDto
��2 C
.
��C D
ContentType
��D O
)
��O P
;
��P Q
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
UploadUserAvatar
��5 E
(
��E F
AvatarUploadDTO
��F U
avatarUploadDto
��V e
)
��e f
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_authService
��! -
.
��- .
UploadUserAvatar
��. >
(
��> ?
avatarUploadDto
��? N
.
��N O
File
��O S
,
��S T
User
��U Y
)
��Y Z
;
��Z [
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
GetUserAvatar
��) 6
(
��6 7
)
��7 8
{
�� 	
var
�� 
stream
�� 
=
�� 
await
�� 
_authService
�� +
.
��+ ,
GetUserAvatar
��, 9
(
��9 :
User
��: >
)
��> ?
;
��? @
if
�� 
(
�� 
stream
�� 
is
�� 
null
�� 
)
�� 
{
�� 
return
�� 
NotFound
�� 
(
��  
$str
��  =
)
��= >
;
��> ?
}
�� 
return
�� 
File
�� 
(
�� 
stream
�� 
,
�� 
$str
��  +
)
��+ ,
;
��, -
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� -
)
��- .
]
��. /
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
DisplayUserAvatar
��) :
(
��: ;
[
��; <
	FromRoute
��< E
]
��E F
string
��G M
userId
��N T
)
��T U
{
�� 	
var
�� 
stream
�� 
=
�� 
await
�� 
_authService
�� +
.
��+ ,
DisplayUserAvatar
��, =
(
��= >
userId
��> D
)
��D E
;
��E F
if
�� 
(
�� 
stream
�� 
is
�� 
null
�� 
)
�� 
{
�� 
return
�� 
NotFound
�� 
(
��  
$str
��  =
)
��= >
;
��> ?
}
�� 
return
�� 
File
�� 
(
�� 
stream
�� 
,
�� 
$str
��  +
)
��+ ,
;
��, -
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
ForgotPassword
��5 C
(
��C D
[
��D E
FromBody
��E M
]
��M N
ForgotPasswordDTO
��O `
forgotPasswordDto
��a r
)
��r s
{
�� 	
var
�� 
result
�� 
=
�� 
await
�� 
_authService
�� +
.
��+ ,
ForgotPassword
��, :
(
��: ;
forgotPasswordDto
��; L
)
��L M
;
��M N
return
�� 

StatusCode
�� 
(
�� 
result
�� $
.
��$ %

StatusCode
��% /
,
��/ 0
result
��1 7
)
��7 8
;
��8 9
}
�� 	
[
�� 	
HttpPost
��	 
(
�� 
$str
�� "
)
��" #
]
��# $
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
ResetPassword
��5 B
(
��B C
[
��C D
FromBody
��D L
]
��L M
ResetPasswordDTO
��N ^
resetPasswordDto
��_ o
)
��o p
{
�� 	
var
�� 
result
�� 
=
�� 
await
�� 
_authService
�� +
.
��+ ,
ResetPassword
��, 9
(
��9 :
resetPasswordDto
��: J
.
��J K
Email
��K P
,
��P Q
resetPasswordDto
��R b
.
��b c
Token
��c h
,
��h i
resetPasswordDto
��  
.
��  !
Password
��! )
)
��) *
;
��* +
return
�� 

StatusCode
�� 
(
�� 
result
�� $
.
��$ %

StatusCode
��% /
,
��/ 0
result
��1 7
)
��7 8
;
��8 9
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� "
)
��" #
]
��# $
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
SendVerifyEmail
��5 D
(
��D E
[
��E F
FromBody
��F N
]
��N O 
SendVerifyEmailDTO
��P b
email
��c h
)
��h i
{
�� 	
var
�� 
user
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByEmailAsync
��* :
(
��: ;
email
��; @
.
��@ A
Email
��A F
)
��F G
;
��G H
if
�� 
(
�� 
user
�� 
.
�� 
EmailConfirmed
�� #
)
��# $
{
�� 
return
�� 
new
�� 
ResponseDTO
�� &
(
��& '
)
��' (
{
�� 
	IsSuccess
�� 
=
�� 
true
��  $
,
��$ %
Message
�� 
=
�� 
$str
�� =
,
��= >

StatusCode
�� 
=
��  
$num
��! $
,
��$ %
Result
�� 
=
�� 
email
�� "
}
�� 
;
�� 
}
�� 
var
�� 
token
�� 
=
�� 
await
�� 
_userManager
�� *
.
��* +1
#GenerateEmailConfirmationTokenAsync
��+ N
(
��N O
user
��O S
)
��S T
;
��T U
var
�� 
confirmationLink
��  
=
��! "
$"
�� 
$str
�� N
{
��N O
user
��O S
.
��S T
Id
��T V
}
��V W
$str
��W ^
{
��^ _
Uri
��_ b
.
��b c
EscapeDataString
��c s
(
��s t
token
��t y
)
��y z
}
��z {
"
��{ |
;
��| }
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
SendVerifyEmail
��1 @
(
��@ A
user
��A E
.
��E F
Email
��F K
,
��K L
confirmationLink
��M ]
)
��] ^
;
��^ _
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	

ActionName
��	 
(
�� 
$str
�� "
)
��" #
]
��# $
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
VerifyEmail
��5 @
(
��@ A
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
userId
�� %
,
��% &
[
�� 
	FromQuery
�� 
]
�� 
string
�� 
token
�� $
)
��$ %
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
VerifyEmail
��1 <
(
��< =
userId
��= C
,
��C D
token
��E J
)
��J K
;
��K L
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
ChangePassword
��5 C
(
��C D
ChangePasswordDTO
��D U
changePasswordDto
��V g
)
��g h
{
�� 	
var
�� 
userId
�� 
=
�� 
User
�� 
.
�� 
FindFirstValue
�� ,
(
��, -

ClaimTypes
��- 7
.
��7 8
NameIdentifier
��8 F
)
��F G
;
��G H
var
�� 
response
�� 
=
�� 
await
��  
_authService
��! -
.
��- .
ChangePassword
��. <
(
��< =
userId
��= C
,
��C D
changePasswordDto
��E V
.
��V W
OldPassword
��W b
,
��b c
changePasswordDto
�� !
.
��! "
NewPassword
��" -
,
��- .
changePasswordDto
��/ @
.
��@ A 
ConfirmNewPassword
��A S
)
��S T
;
��T U
if
�� 
(
�� 
response
�� 
.
�� 
	IsSuccess
�� "
)
��" #
{
�� 
return
�� 
Ok
�� 
(
�� 
response
�� "
.
��" #
Message
��# *
)
��* +
;
��+ ,
}
�� 
else
�� 
{
�� 
return
�� 

BadRequest
�� !
(
��! "
response
��" *
.
��* +
Message
��+ 2
)
��2 3
;
��3 4
}
�� 
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
SignIn
��5 ;
(
��; <
[
��< =
FromBody
��= E
]
��E F
SignDTO
��G N
signDto
��O V
)
��V W
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
SignIn
��1 7
(
��7 8
signDto
��8 ?
)
��? @
;
��@ A
return
�� 

StatusCode
�� 
(
�� 
this
�� "
.
��" #
responseDto
��# .
.
��. /

StatusCode
��/ 9
,
��9 :
responseDto
��; F
)
��F G
;
��G H
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
Refresh
��5 <
(
��< =
[
��= >
FromBody
��> F
]
��F G
JwtTokenDTO
��H S
token
��T Y
)
��Y Z
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
Refresh
��1 8
(
��8 9
token
��9 >
.
��> ?
RefreshToken
��? K
)
��K L
;
��L M
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� "
)
��" #
]
��# $
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
CheckEmailExist
��5 D
(
��D E
[
��E F
FromBody
��F N
]
��N O
string
��P V
email
��W \
)
��\ ]
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
CheckEmailExist
��1 @
(
��@ A
email
��A F
)
��F G
;
��G H
return
�� 

StatusCode
�� 
(
�� 
this
�� "
.
��" #
responseDto
��# .
.
��. /

StatusCode
��/ 9
,
��9 :
responseDto
��; F
)
��F G
;
��G H
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� )
)
��) *
]
��* +
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4#
CheckPhoneNumberExist
��5 J
(
��J K
[
��K L
FromBody
��L T
]
��T U
string
��V \
phoneNumber
��] h
)
��h i
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1#
CheckPhoneNumberExist
��1 F
(
��F G
phoneNumber
��G R
)
��R S
;
��S T
return
�� 

StatusCode
�� 
(
�� 
this
�� "
.
��" #
responseDto
��# .
.
��. /

StatusCode
��/ 9
,
��9 :
responseDto
��; F
)
��F G
;
��G H
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4$
CompleteStudentProfile
��5 K
(
��K L'
CompleteStudentProfileDTO
�� %'
completeStudentProfileDto
��& ?
)
��? @
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1$
CompleteStudentProfile
��1 G
(
��G H
User
��H L
,
��L M'
completeStudentProfileDto
��N g
)
��g h
;
��h i
return
�� 

StatusCode
�� 
(
�� 
this
�� "
.
��" #
responseDto
��# .
.
��. /

StatusCode
��/ 9
,
��9 :
responseDto
��; F
)
��F G
;
��G H
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� #
)
��# $
]
��$ %
[
�� 	
	Authorize
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4'
CompleteInstructorProfile
��5 N
(
��N O*
CompleteInstructorProfileDTO
�� (*
completeInstructorProfileDto
��) E
)
��E F
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1'
CompleteInstructorProfile
��1 J
(
��J K
User
��K O
,
��O P*
completeInstructorProfileDto
��Q m
)
��m n
;
��n o
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPost
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
��  
]
��  !
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
SignInByGoogle
��5 C
(
��C D
SignInByGoogleDTO
��D U
signInByGoogleDto
��V g
)
��g h
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_authService
��! -
.
��- .
SignInByGoogle
��. <
(
��< =
signInByGoogleDto
��= N
)
��N O
;
��O P
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	
HttpGet
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
GetUserInfo
��5 @
(
��@ A
)
��A B
{
�� 	
var
�� 
response
�� 
=
�� 
await
��  
_authService
��! -
.
��- .
GetUserInfo
��. 9
(
��9 :
User
��: >
)
��> ?
;
��? @
return
�� 

StatusCode
�� 
(
�� 
response
�� &
.
��& '

StatusCode
��' 1
,
��1 2
response
��3 ;
)
��; <
;
��< =
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
��  
)
��  !
]
��! "
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
UpdateStudent
��5 B
(
��B C
[
��C D
FromBody
��D L
]
��L M%
UpdateStudentProfileDTO
��N e

studentDTO
��f p
)
��p q
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
UpdateStudent
��1 >
(
��> ?

studentDTO
��? I
,
��I J
User
��J N
)
��N O
;
��O P
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
[
�� 	
HttpPut
��	 
]
�� 
[
�� 	
Route
��	 
(
�� 
$str
�� #
)
��# $
]
��$ %
public
�� 
async
�� 
Task
�� 
<
�� 
ActionResult
�� &
<
��& '
ResponseDTO
��' 2
>
��2 3
>
��3 4
UpdateInstructor
��5 E
(
��E F
[
��F G
FromBody
��G O
]
��O P'
UpdateIntructorProfileDTO
��Q j
intructorDTO
��k w
)
��w x
{
�� 	
var
�� 
responseDto
�� 
=
�� 
await
�� #
_authService
��$ 0
.
��0 1
UpdateInstructor
��1 A
(
��A B
intructorDTO
��B N
,
��N O
User
��P T
)
��T U
;
��U V
return
�� 

StatusCode
�� 
(
�� 
responseDto
�� )
.
��) *

StatusCode
��* 4
,
��4 5
responseDto
��6 A
)
��A B
;
��B C
}
�� 	
}
�� 
}�� 