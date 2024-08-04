—D
TD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. "
AddHttpContextAccessor '
(' (
)( )
;) *
builder 
. 
Services 
. 
AddHttpClient 
( 
)  
;  !
builder 
. 
Services 
. 
AddDbContext 
<  
ApplicationDbContext 2
>2 3
(3 4
options4 ;
=>< >
{ 
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C"
StaticConnectionStringC Y
.Y Z#
SQLDB_DefaultConnectionZ q
)q r
)r s
;s t
} 
) 
; 
builder 
. 
Services 
. 
	Configure 
< .
"DataProtectionTokenProviderOptions =
>= >
(> ?
options? F
=>G I
options 
. 
TokenLifespan 
= 
TimeSpan $
.$ %
FromMinutes% 0
(0 1
$num1 3
)3 4
)4 5
;5 6
builder!! 
.!! 
Services!! 
.!! 
AddAutoMapper!! 
(!! 
typeof!! %
(!!% &
AutoMapperProfile!!& 7
)!!7 8
)!!8 9
;!!9 :
builder%% 
.%% 
Services%% 
.%% 
RegisterServices%% !
(%%! "
)%%" #
;%%# $
builder)) 
.)) 
Services)) 
.)) 
AddFirebaseServices)) $
())$ %
)))% &
;))& '
builder-- 
.-- 
AddRedisCache-- 
(-- 
)-- 
;-- 
builder11 
.11 
AddHangfireServices11 
(11 
)11 
;11 
builder33 
.33 
Services33 
.33 #
AddEndpointsApiExplorer33 (
(33( )
)33) *
;33* +
builder77 
.77  
AddAppAuthentication77 
(77 
)77 
;77 
builder99 
.99 
Services99 
.99 
AddAuthorization99 !
(99! "
)99" #
;99# $
builder== 
.== 
AddSwaggerGen== 
(== 
)== 
;== 
builder@@ 
.@@ 
Services@@ 
.@@ 

AddSignalR@@ 
(@@ 
)@@ 
;@@ 
builderBB 
.BB 
ServicesBB 
.BB 
AddCorsBB 
(BB 
optionsBB  
=>BB! #
{CC 
varDD 
originDefaultDD 
=DD 
builderDD 
.DD  
ConfigurationDD  -
[DD- .
$strDD. D
]DDD E
;DDE F
varEE 
originFirebaseEE 
=EE 
builderEE  
.EE  !
ConfigurationEE! .
[EE. /
$strEE/ M
]EEM N
;EEN O
varFF 
originVercelFF 
=FF 
builderFF 
.FF 
ConfigurationFF ,
[FF, -
$strFF- I
]FFI J
;FFJ K
varGG 
	originK8SGG 
=GG 
builderGG 
.GG 
ConfigurationGG )
[GG) *
$strGG* C
]GGC D
;GGD E
optionsHH 
.HH 
	AddPolicyHH 
(HH 
$strHH +
,HH+ ,
builderII 
=>II 
builderII 
.JJ 
WithOriginsJJ 
(JJ 
originDefaultJJ &
,JJ& '
originFirebaseJJ( 6
,JJ6 7
originVercelJJ8 D
,JJD E
	originK8SJJF O
)JJO P
.KK 
AllowAnyHeaderKK 
(KK 
)KK 
.LL 
AllowAnyMethodLL 
(LL 
)LL 
.MM 
AllowCredentialsMM 
(MM 
)MM 
)MM  
;MM  !
}NN 
)NN 
;NN 
builderQQ 
.QQ 
ServicesQQ 
.QQ +
AddApplicationInsightsTelemetryQQ 0
(QQ0 1
builderQQ1 8
.QQ8 9
ConfigurationQQ9 F
[QQF G
$strQQG o
]QQo p
)QQp q
;QQq r
varSS 
appSS 
=SS 	
builderSS
 
.SS 
BuildSS 
(SS 
)SS 
;SS 
ApplyMigrationUU 
(UU 
)UU 
;UU 
StripeConfigurationWW 
.WW 
ApiKeyWW 
=WW 
builderWW $
.WW$ %
ConfigurationWW% 2
.WW2 3

GetSectionWW3 =
(WW= >
$strWW> P
)WWP Q
.WWQ R
GetWWR U
<WWU V
stringWWV \
>WW\ ]
(WW] ^
)WW^ _
;WW_ `
ifZZ 
(ZZ 
appZZ 
.ZZ 
EnvironmentZZ 
.ZZ 
IsDevelopmentZZ !
(ZZ! "
)ZZ" #
)ZZ# $
{[[ 
app\\ 
.\\ 

UseSwagger\\ 
(\\ 
)\\ 
;\\ 
app]] 
.]] 
UseSwaggerUI]] 
(]] 
)]] 
;]] 
}^^ 
app`` 
.`` 
UseCors`` 
(`` 
$str`` !
)``! "
;``" #
appbb 
.bb  
UseHangfireDashboardbb 
(bb 
)bb 
;bb 
appdd 
.dd  
MapHangfireDashboarddd 
(dd 
$strdd $
)dd$ %
;dd% &
RecurringJobff 
.ff 
AddOrUpdateff 
<ff 
IAuthServiceff %
>ff% &
(ff& '
jobff' *
=>ff+ -
jobff. 1
.ff1 2
SendClearEmailff2 @
(ff@ A
$numffA B
)ffB C
,ffC D
$strffE R
)ffR S
;ffS T
RecurringJobgg 
.gg 
AddOrUpdategg 
<gg 
IAuthServicegg %
>gg% &
(gg& '
jobgg' *
=>gg+ -
jobgg. 1
.gg1 2
	ClearUsergg2 ;
(gg; <
)gg< =
,gg= >
$strgg? L
)ggL M
;ggM N
appii 
.ii 
UseHttpsRedirectionii 
(ii 
)ii 
;ii 
appkk 
.kk 
UseAuthenticationkk 
(kk 
)kk 
;kk 
appmm 
.mm 
UseAuthorizationmm 
(mm 
)mm 
;mm 
appoo 
.oo 
MapControllersoo 
(oo 
)oo 
;oo 
appqq 
.qq 
MapHubqq 

<qq
 
NotificationHubqq 
>qq 
(qq 
$strqq 0
)qq0 1
.qq1 2 
RequireAuthorizationqq2 F
(qqF G
)qqG H
;qqH I
appss 
.ss 
Runss 
(ss 
)ss 	
;ss	 

voiduu 
ApplyMigrationuu 
(uu 
)uu 
{vv 
usingww 	
(ww
 
varww 
scopeww 
=ww 
appww 
.ww 
Servicesww #
.ww# $
CreateScopeww$ /
(ww/ 0
)ww0 1
)ww1 2
{xx 
varyy 
contextyy 
=yy 
scopeyy 
.yy 
ServiceProvideryy +
.yy+ ,
GetRequiredServiceyy, >
<yy> ? 
ApplicationDbContextyy? S
>yyS T
(yyT U
)yyU V
;yyV W
if{{ 

({{ 
context{{ 
.{{ 
Database{{ 
.{{  
GetPendingMigrations{{ 1
({{1 2
){{2 3
.{{3 4
Any{{4 7
({{7 8
){{8 9
){{9 :
{|| 	
context}} 
.}} 
Database}} 
.}} 
Migrate}} $
(}}$ %
)}}% &
;}}& '
}~~ 	
} 
}ÄÄ √*
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
}BB Æ?
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
servicesJJ 
.JJ 
	AddScopedJJ 
<JJ "
ICourseProgressServiceJJ 1
,JJ1 2!
CourseProgressServiceJJ3 H
>JJH I
(JJI J
)JJJ K
;JJK L
servicesLL 
.LL 
	AddScopedLL 
<LL 
ICompanyServiceLL *
,LL* +
CompanyServiceLL, :
>LL: ;
(LL; <
)LL< =
;LL= >
servicesNN 
.NN 
	AddScopedNN 
<NN 
ITermOfUseServiceNN ,
,NN, -
TermOfUseServiceNN. >
>NN> ?
(NN? @
)NN@ A
;NNA B
servicesPP 
.PP 
	AddScopedPP 
<PP 
IPrivacyServicePP *
,PP* +
PrivacyServicePP, :
>PP: ;
(PP; <
)PP< =
;PP= >
servicesSS 
.SS 
AddIdentitySS 
<SS 
ApplicationUserSS ,
,SS, -
IdentityRoleSS. :
>SS: ;
(SS; <
)SS< =
.TT $
AddEntityFrameworkStoresTT %
<TT% & 
ApplicationDbContextTT& :
>TT: ;
(TT; <
)TT< =
.UU $
AddDefaultTokenProvidersUU %
(UU% &
)UU& '
;UU' (
returnXX 
servicesXX 
;XX 
}YY 
}ZZ ⁄

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
} ıW
jD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\WebsiteController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
WebsiteController		 "
:		# $
ControllerBase		% 3
{

 
private 
readonly 
ICompanyService (
_companyService) 8
;8 9
private 
readonly 
ITermOfUseService *
_termOfUseService+ <
;< =
private 
readonly 
IPrivacyService (
_privacyService) 8
;8 9
public 
WebsiteController  
( 	
ICompanyService 
companyService *
,* +
ITermOfUseService 
termOfUseService .
,. /
IPrivacyService 
privacyService *
) 	
{ 	
_companyService 
= 
companyService ,
;, -
_termOfUseService 
= 
termOfUseService  0
;0 1
_privacyService 
= 
privacyService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4

GetCompany5 ?
(? @
)@ A
{ 	
var   
responseDto   
=   
await   #
_companyService  $ 3
.  3 4

GetCompany  4 >
(  > ?
)  ? @
;  @ A
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
HttpPut$$	 
($$ 
$str$$ 
)$$ 
]$$ 
public%% 
async%% 
Task%% 
<%% 
ActionResult%% &
<%%& '
ResponseDTO%%' 2
>%%2 3
>%%3 4
UpdateCompany%%5 B
(%%B C
[%%C D
FromBody%%D L
]%%L M
UpdateCompanyDTO%%N ^

companyDto%%_ i
)%%i j
{&& 	
var'' 
responseDto'' 
='' 
await'' #
_companyService''$ 3
.''3 4
UpdateCompany''4 A
(''A B

companyDto''B L
)''L M
;''M N
return(( 

StatusCode(( 
((( 
responseDto(( )
.(() *

StatusCode((* 4
,((4 5
responseDto((6 A
)((A B
;((B C
})) 	
[// 	
HttpGet//	 
(// 
$str// 
)// 
]// 
public00 
async00 
Task00 
<00 
ActionResult00 &
<00& '
ResponseDTO00' 2
>002 3
>003 4
GetPrivacies005 A
(00A B
)00B C
{11 	
var22 
responseDto22 
=22 
await22 #
_privacyService22$ 3
.223 4
GetPrivacies224 @
(22@ A
)22A B
;22B C
return33 

StatusCode33 
(33 
responseDto33 )
.33) *

StatusCode33* 4
,334 5
responseDto336 A
)33A B
;33B C
}44 	
[66 	
HttpGet66	 
(66 
$str66 $
)66$ %
]66% &
public77 
async77 
Task77 
<77 
ActionResult77 &
<77& '
ResponseDTO77' 2
>772 3
>773 4

GetPrivacy775 ?
(77? @
Guid77@ D
id77E G
)77G H
{88 	
var99 
responseDto99 
=99 
await99 #
_privacyService99$ 3
.993 4

GetPrivacy994 >
(99> ?
id99? A
)99A B
;99B C
return:: 

StatusCode:: 
(:: 
responseDto:: )
.::) *

StatusCode::* 4
,::4 5
responseDto::6 A
)::A B
;::B C
};; 	
[== 	
HttpPost==	 
(== 
$str== 
)== 
]== 
public>> 
async>> 
Task>> 
<>> 
ActionResult>> &
<>>& '
ResponseDTO>>' 2
>>>2 3
>>>3 4
CreatePrivacy>>5 B
(>>B C
[>>C D
FromBody>>D L
]>>L M
CreatePrivacyDTO>>N ^

privacyDto>>_ i
)>>i j
{?? 	
var@@ 
responseDto@@ 
=@@ 
await@@ #
_privacyService@@$ 3
.@@3 4
CreatePrivacy@@4 A
(@@A B

privacyDto@@B L
)@@L M
;@@M N
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
(DD 
$strDD 
)DD 
]DD 
publicEE 
asyncEE 
TaskEE 
<EE 
ActionResultEE &
<EE& '
ResponseDTOEE' 2
>EE2 3
>EE3 4
UpdatePrivacyEE5 B
(EEB C
[EEC D
FromBodyEED L
]EEL M
UpdatePrivacyDTOEEN ^

privacyDtoEE_ i
)EEi j
{FF 	
varGG 
responseDtoGG 
=GG 
awaitGG #
_privacyServiceGG$ 3
.GG3 4
UpdatePrivacyGG4 A
(GGA B

privacyDtoGGB L
)GGL M
;GGM N
returnHH 

StatusCodeHH 
(HH 
responseDtoHH )
.HH) *

StatusCodeHH* 4
,HH4 5
responseDtoHH6 A
)HHA B
;HHB C
}II 	
[KK 	

HttpDeleteKK	 
(KK 
$strKK '
)KK' (
]KK( )
publicLL 
asyncLL 
TaskLL 
<LL 
ActionResultLL &
<LL& '
ResponseDTOLL' 2
>LL2 3
>LL3 4
DeletePrivacyLL5 B
(LLB C
GuidLLC G
idLLH J
)LLJ K
{MM 	
varNN 
responseDtoNN 
=NN 
awaitNN #
_privacyServiceNN$ 3
.NN3 4
DeletePrivacyNN4 A
(NNA B
idNNB D
)NND E
;NNE F
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
[VV 	
HttpGetVV	 
(VV 
$strVV 
)VV 
]VV  
publicWW 
asyncWW 
TaskWW 
<WW 
ActionResultWW &
<WW& '
ResponseDTOWW' 2
>WW2 3
>WW3 4
GetTermOfUsesWW5 B
(WWB C
)WWC D
{XX 	
varYY 
responseDtoYY 
=YY 
awaitYY #
_termOfUseServiceYY$ 5
.YY5 6
GetTermOfUsesYY6 C
(YYC D
)YYD E
;YYE F
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
}[[ 	
[]] 	
HttpGet]]	 
(]] 
$str]] (
)]]( )
]]]) *
public^^ 
async^^ 
Task^^ 
<^^ 
ActionResult^^ &
<^^& '
ResponseDTO^^' 2
>^^2 3
>^^3 4
GetTermOfUse^^5 A
(^^A B
Guid^^B F
id^^G I
)^^I J
{__ 	
var`` 
responseDto`` 
=`` 
await`` #
_termOfUseService``$ 5
.``5 6
GetTermOfUse``6 B
(``B C
id``C E
)``E F
;``F G
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
(dd 
$strdd 
)dd  
]dd  !
publicee 
asyncee 
Taskee 
<ee 
ActionResultee &
<ee& '
ResponseDTOee' 2
>ee2 3
>ee3 4
CreateTermOfUseee5 D
(eeD E
[eeE F
FromBodyeeF N
]eeN O
CreateTermOfUseDTOeeP b
termOfUseDtoeec o
)eeo p
{ff 	
vargg 
responseDtogg 
=gg 
awaitgg #
_termOfUseServicegg$ 5
.gg5 6
CreateTermOfUsegg6 E
(ggE F
termOfUseDtoggF R
)ggR S
;ggS T
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
[kk 	
HttpPutkk	 
(kk 
$strkk 
)kk 
]kk  
publicll 
asyncll 
Taskll 
<ll 
ActionResultll &
<ll& '
ResponseDTOll' 2
>ll2 3
>ll3 4
UpdateTermOfUsell5 D
(llD E
[llE F
FromBodyllF N
]llN O
UpdateTermOfUseDTOllP b
termOfUseDtollc o
)llo p
{mm 	
varnn 
responseDtonn 
=nn 
awaitnn #
_termOfUseServicenn$ 5
.nn5 6
UpdateTermOfUsenn6 E
(nnE F
termOfUseDtonnF R
)nnR S
;nnS T
returnoo 

StatusCodeoo 
(oo 
responseDtooo )
.oo) *

StatusCodeoo* 4
,oo4 5
responseDtooo6 A
)ooA B
;ooB C
}pp 	
[rr 	

HttpDeleterr	 
(rr 
$strrr +
)rr+ ,
]rr, -
publicss 
asyncss 
Taskss 
<ss 
ActionResultss &
<ss& '
ResponseDTOss' 2
>ss2 3
>ss3 4
DeleteTermOfUsess5 D
(ssD E
GuidssE I
idssJ L
)ssL M
{tt 	
varuu 
responseDtouu 
=uu 
awaituu #
_termOfUseServiceuu$ 5
.uu5 6
DeleteTermOfUseuu6 E
(uuE F
iduuF H
)uuH I
;uuI J
returnvv 

StatusCodevv 
(vv 
responseDtovv )
.vv) *

StatusCodevv* 4
,vv4 5
responseDtovv6 A
)vvA B
;vvB C
}ww 	
}zz 
}{{ €ù
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
] 
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
],, 
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
.44* +
AdminStudent44+ 7
)447 8
]448 9
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
ÅÅ 	
HttpPost
ÅÅ	 
]
ÅÅ 
[
ÇÇ 	
Route
ÇÇ	 
(
ÇÇ 
$str
ÇÇ .
)
ÇÇ. /
]
ÇÇ/ 0
[
ÉÉ 	
	Authorize
ÉÉ	 
(
ÉÉ 
Roles
ÉÉ 
=
ÉÉ 
StaticUserRoles
ÉÉ *
.
ÉÉ* +
Admin
ÉÉ+ 0
)
ÉÉ0 1
]
ÉÉ1 2
public
ÑÑ 
async
ÑÑ 
Task
ÑÑ 
<
ÑÑ 
ActionResult
ÑÑ &
<
ÑÑ& '
ResponseDTO
ÑÑ' 2
>
ÑÑ2 3
>
ÑÑ3 4
ExportStudent
ÑÑ5 B
(
ÖÖ 	
[
ÜÜ 
	FromRoute
ÜÜ 
]
ÜÜ 
int
ÜÜ 
month
ÜÜ !
,
ÜÜ! "
[
áá 
	FromRoute
áá 
]
áá 
int
áá 
year
áá  
)
àà 	
{
ââ 	
var
ää 
userId
ää 
=
ää 
User
ää 
.
ää 
Claims
ää $
.
ää$ %
FirstOrDefault
ää% 3
(
ää3 4
x
ää4 5
=>
ää6 8
x
ää9 :
.
ää: ;
Type
ää; ?
==
ää@ B

ClaimTypes
ääC M
.
ääM N
NameIdentifier
ääN \
)
ää\ ]
?
ää] ^
.
ää^ _
Value
ää_ d
;
ääd e
BackgroundJob
ãã 
.
ãã 
Enqueue
ãã !
<
ãã! "
IStudentsService
ãã" 2
>
ãã2 3
(
ãã3 4
job
ãã4 7
=>
ãã8 :
job
ãã; >
.
ãã> ?
ExportStudents
ãã? M
(
ããM N
userId
ããN T
,
ããT U
month
ããV [
,
ãã[ \
year
ãã] a
)
ããa b
)
ããb c
;
ããc d
return
åå 
Ok
åå 
(
åå 
)
åå 
;
åå 
}
çç 	
[
èè 	
HttpGet
èè	 
]
èè 
[
êê 	
Route
êê	 
(
êê 
$str
êê $
)
êê$ %
]
êê% &
[
ëë 	
	Authorize
ëë	 
(
ëë 
Roles
ëë 
=
ëë 
StaticUserRoles
ëë *
.
ëë* +
Admin
ëë+ 0
)
ëë0 1
]
ëë1 2
public
íí 
async
íí 
Task
íí 
<
íí 
IActionResult
íí '
>
íí' (#
DownloadStudentExport
íí) >
(
íí> ?
[
íí? @
	FromRoute
íí@ I
]
ííI J
string
ííK Q
fileName
ííR Z
)
ííZ [
{
ìì 	
var
îî "
closedXmlResponseDto
îî $
=
îî% &
await
îî' ,
_studentsService
îî- =
.
îî= >
DownloadStudents
îî> N
(
îîN O
fileName
îîO W
)
îîW X
;
îîX Y
var
ïï 
stream
ïï 
=
ïï "
closedXmlResponseDto
ïï -
.
ïï- .
Stream
ïï. 4
;
ïï4 5
var
ññ 
contentType
ññ 
=
ññ "
closedXmlResponseDto
ññ 2
.
ññ2 3
ContentType
ññ3 >
;
ññ> ?
if
òò 
(
òò 
stream
òò 
is
òò 
null
òò 
||
òò !
contentType
òò" -
is
òò. 0
null
òò1 5
)
òò5 6
{
ôô 
return
öö 
NotFound
öö 
(
öö  
)
öö  !
;
öö! "
}
õõ 
return
ùù 
File
ùù 
(
ùù 
stream
ùù 
,
ùù 
contentType
ùù  +
,
ùù+ ,
fileName
ùù- 5
)
ùù5 6
;
ùù6 7
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
°° 4
)
°°4 5
]
°°5 6
[
¢¢ 	
	Authorize
¢¢	 
(
¢¢ 
Roles
¢¢ 
=
¢¢ 
StaticUserRoles
¢¢ *
.
¢¢* +
AdminStudent
¢¢+ 7
)
¢¢7 8
]
¢¢8 9
public
££ 
async
££ 
Task
££ 
<
££ 
ActionResult
££ &
<
££& '
ResponseDTO
££' 2
>
££2 3
>
££3 4*
TotalPricesCourseByStudentId
££5 Q
(
££Q R
[
££R S
	FromRoute
££S \
]
££\ ]
Guid
££^ b
	studentId
££c l
)
££l m
{
§§ 	
var
•• 
responseDto
•• 
=
•• 
await
•• #
_studentsService
••$ 4
.
••4 5+
TotalPricesCoursesByStudentId
••5 R
(
••R S
	studentId
••S \
)
••\ ]
;
••] ^
return
¶¶ 

StatusCode
¶¶ 
(
¶¶ 
responseDto
¶¶ )
.
¶¶) *

StatusCode
¶¶* 4
,
¶¶4 5
responseDto
¶¶6 A
)
¶¶A B
;
¶¶B C
}
ßß 	
[
©© 	
HttpGet
©©	 
]
©© 
[
™™ 	
Route
™™	 
(
™™ 
$str
™™ (
)
™™( )
]
™™) *
[
´´ 	
	Authorize
´´	 
(
´´ 
Roles
´´ 
=
´´ 
StaticUserRoles
´´ *
.
´´* +
AdminStudent
´´+ 7
)
´´7 8
]
´´8 9
public
¨¨ 
async
¨¨ 
Task
¨¨ 
<
¨¨ 
ActionResult
¨¨ &
<
¨¨& '
ResponseDTO
¨¨' 2
>
¨¨2 3
>
¨¨3 4&
GetAllCoursesByStudentId
¨¨5 M
(
¨¨M N
[
¨¨N O
	FromRoute
¨¨O X
]
¨¨X Y
Guid
¨¨Z ^
	studentId
¨¨_ h
)
¨¨h i
{
≠≠ 	
var
ÆÆ 
responseDto
ÆÆ 
=
ÆÆ 
await
ÆÆ #
_studentsService
ÆÆ$ 4
.
ÆÆ4 5%
GetAllCourseByStudentId
ÆÆ5 L
(
ÆÆL M
	studentId
ÆÆM V
)
ÆÆV W
;
ÆÆW X
return
ØØ 

StatusCode
ØØ 
(
ØØ 
responseDto
ØØ )
.
ØØ) *

StatusCode
ØØ* 4
,
ØØ4 5
responseDto
ØØ6 A
)
ØØA B
;
ØØB C
}
∞∞ 	
[
≤≤ 	
HttpGet
≤≤	 
]
≤≤ 
[
≥≥ 	
Route
≥≥	 
(
≥≥ 
$str
≥≥ 5
)
≥≥5 6
]
≥≥6 7
[
¥¥ 	
	Authorize
¥¥	 
(
¥¥ 
Roles
¥¥ 
=
¥¥ 
StaticUserRoles
¥¥ *
.
¥¥* +
AdminStudent
¥¥+ 7
)
¥¥7 8
]
¥¥8 9
public
µµ 
async
µµ 
Task
µµ 
<
µµ 
ActionResult
µµ &
<
µµ& '
ResponseDTO
µµ' 2
>
µµ2 3
>
µµ3 4*
GetAllCoursesStudentEnrolled
µµ5 Q
(
µµQ R
[
µµR S
	FromRoute
µµS \
]
µµ\ ]
Guid
µµ^ b
	studentId
µµc l
)
µµl m
{
∂∂ 	
var
∑∑ 
responseDto
∑∑ 
=
∑∑ 
await
∑∑ #
_studentsService
∑∑$ 4
.
∑∑4 5)
GetAllCourseStudentEnrolled
∑∑5 P
(
∑∑P Q
	studentId
∑∑Q Z
)
∑∑Z [
;
∑∑[ \
return
∏∏ 

StatusCode
∏∏ 
(
∏∏ 
responseDto
∏∏ )
.
∏∏) *

StatusCode
∏∏* 4
,
∏∏4 5
responseDto
∏∏6 A
)
∏∏A B
;
∏∏B C
}
ππ 	
}
∫∫ 
}ªª ∑=
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
] 
[ 	
	Authorize	 
( 
Roles 
= 
StaticUserRoles *
.* +
AdminInstructor+ :
): ;
]; <
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4!
GetTransactionHistory5 J
( 	
[ 
	FromQuery 
] 
string 
? 
userId  &
,& '
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[   
	FromQuery   
]   
string   
?   
sortBy    &
,  & '
[!! 
	FromQuery!! 
]!! 
bool!! 
?!! 
isAscending!! )
,!!) *
["" 
	FromQuery"" 
]"" 
int"" 

pageNumber"" &
=""' (
$num"") *
,""* +
[## 
	FromQuery## 
]## 
int## 
pageSize## $
=##% &
$num##' (
)$$ 	
{%% 	
var&& 
responseDto&& 
=&& 
await&& #
_transactionService&&$ 7
.&&7 8
GetTransactions&&8 G
('' 
User(( 
,(( 
userId)) 
,)) 
filterOn** 
,** 
filterQuery++ 
,++ 
sortBy,, 
,,, 
isAscending-- 
,-- 

pageNumber.. 
,.. 
pageSize// 
)00 
;00 
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
[55 	
HttpPost55	 
]55 
[66 	
Route66	 
(66 
$str66 
)66  
]66  !
[77 	
	Authorize77	 
(77 
Roles77 
=77 
StaticUserRoles77 *
.77* +

Instructor77+ 5
)775 6
]776 7
public88 
async88 
Task88 
<88 
ActionResult88 &
<88& '
ResponseDTO88' 2
>882 3
>883 4(
CreateStripeConnectedAccount885 Q
(99 	+
CreateStripeConnectedAccountDTO:: ++
createStripeConnectedAccountDto::, K
);; 	
{<< 	
var== 
responseDto== 
=== 
await== #
_paymentService==$ 3
.==3 4(
CreateStripeConnectedAccount==4 P
(==P Q
User==Q U
,==U V+
createStripeConnectedAccountDto==W v
)==v w
;==w x
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
(CC 
RolesCC 
=CC 
StaticUserRolesCC *
.CC* +
AdminCC+ 0
)CC0 1
]CC1 2
publicDD 
asyncDD 
TaskDD 
<DD 
ActionResultDD &
<DD& '
ResponseDTODD' 2
>DD2 3
>DD3 4 
CreateStripeTransferDD5 I
(EE 	#
CreateStripeTransferDTOFF ##
createStripeTransferDtoFF$ ;
)FF; <
{GG 	
varHH 
responseDtoHH 
=HH 
awaitHH #
_paymentServiceHH$ 3
.HH3 4 
CreateStripeTransferHH4 H
(HHH I#
createStripeTransferDtoHHI `
)HH` a
;HHa b
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
[LL 	
HttpPostLL	 
]LL 
[MM 	
RouteMM	 
(MM 
$strMM 
)MM 
]MM  
[NN 	
	AuthorizeNN	 
(NN 
RolesNN 
=NN 
StaticUserRolesNN *
.NN* +

InstructorNN+ 5
)NN5 6
]NN6 7
publicOO 
asyncOO 
TaskOO 
<OO 
ActionResultOO &
<OO& '
ResponseDTOOO' 2
>OO2 3
>OO3 4
CreateStripePayoutOO5 G
(OOG H!
CreateStripePayoutDTOOOH ]!
createStripePayoutDtoOO^ s
)OOs t
{PP 	
varQQ 
responseDtoQQ 
=QQ 
awaitQQ #
_paymentServiceQQ$ 3
.QQ3 4
CreateStripePayoutQQ4 F
(QQF G
UserQQG K
,QQK L!
createStripePayoutDtoQQM b
)QQb c
;QQc d
returnRR 

StatusCodeRR 
(RR 
responseDtoRR )
.RR) *

StatusCodeRR* 4
,RR4 5
responseDtoRR6 A
)RRA B
;RRB C
}SS 	
[UU 	
HttpPostUU	 
]UU 
[VV 	
RouteVV	 
(VV 
$strVV 
)VV 
]VV 
[WW 	
	AuthorizeWW	 
(WW 
RolesWW 
=WW 
StaticUserRolesWW *
.WW* +

InstructorWW+ 5
)WW5 6
]WW6 7
publicXX 
asyncXX 
TaskXX 
<XX 
ActionResultXX &
<XX& '
ResponseDTOXX' 2
>XX2 3
>XX3 4
AddStripeCardXX5 B
(YY 	
AddStripeCardDTOZZ 
addStripeCardDtoZZ -
)[[ 	
{\\ 	
var]] 
responseDto]] 
=]] 
await]] #
_paymentService]]$ 3
.]]3 4
AddStripeCard]]4 A
(]]A B
addStripeCardDto]]B R
)]]R S
;]]S T
return^^ 

StatusCode^^ 
(^^ 
responseDto^^ )
.^^) *

StatusCode^^* 4
,^^4 5
responseDto^^6 A
)^^A B
;^^B C
}__ 	
}`` 
}aa Ÿ?
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
( 
Roles 
= 
StaticUserRoles *
.* +
Student+ 2
)2 3
]3 4
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
(CC 
RolesCC 
=CC 
StaticUserRolesCC *
.CC* +
StudentCC+ 2
)CC2 3
]CC3 4
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
(OO 
RolesOO 
=OO 
StaticUserRolesOO *
.OO* +
AdminStudentOO+ 7
)OO7 8
]OO8 9
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
}bb ﬂ1
hD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\LevelController.cs
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
LevelController  
:! "
ControllerBase# 1
{ 
private 
readonly 
ILevelService &
_levelService' 4
;4 5
public 
LevelController 
( 
ILevelService ,
levelService- 9
)9 :
{ 	
_levelService 
= 
levelService (
;( )
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
>3 4
	GetLevels5 >
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
$num' (
) 	
{ 	
var 
responseDto 
= 
await #
_levelService$ 1
.1 2
	GetLevels2 ;
(   
User!! 
,!! 
filterOn"" 
,"" 
filterQuery## 
,## 
sortBy$$ 
,$$ 
isAscending%% 
,%% 

pageNumber&& 
,&& 
pageSize'' 
)(( 
;(( 
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
$str-- 
)--  
]--  !
public.. 
async.. 
Task.. 
<.. 
ActionResult.. &
<..& '
ResponseDTO..' 2
>..2 3
>..3 4
GetLevel..5 =
(// 	
[00 
	FromRoute00 
]00 
Guid00 
levelId00 $
)11 	
{22 	
var33 
responseDto33 
=33 
await33 #
_levelService33$ 1
.331 2
GetLevel332 :
(33: ;
User33; ?
,33? @
levelId33A H
)33H I
;33I J
return44 

StatusCode44 
(44 
responseDto44 )
.44) *

StatusCode44* 4
,444 5
responseDto446 A
)44A B
;44B C
}55 	
[77 	
HttpPost77	 
]77 
[88 	
	Authorize88	 
(88 
Roles88 
=88 
StaticUserRoles88 *
.88* +
Admin88+ 0
)880 1
]881 2
public99 
async99 
Task99 
<99 
ActionResult99 &
<99& '
ResponseDTO99' 2
>992 3
>993 4
CreateLevel995 @
(:: 	
[;; 
FromBody;; 
];; 
CreateLevelDTO;; %
createLevelDto;;& 4
)<< 	
{== 	
var>> 
responseDto>> 
=>> 
await>> #
_levelService>>$ 1
.>>1 2
CreateLevel>>2 =
(>>= >
User>>> B
,>>B C
createLevelDto>>D R
)>>R S
;>>S T
return?? 

StatusCode?? 
(?? 
responseDto?? )
.??) *

StatusCode??* 4
,??4 5
responseDto??6 A
)??A B
;??B C
}@@ 	
[BB 	
HttpPutBB	 
]BB 
publicCC 
asyncCC 
TaskCC 
<CC 
ActionResultCC &
<CC& '
ResponseDTOCC' 2
>CC2 3
>CC3 4
UpdateLevelCC5 @
(DD 	
[EE 
FromBodyEE 
]EE 
UpdateLevelDTOEE %
updateLevelDtoEE& 4
)FF 	
{GG 	
varHH 
responseDtoHH 
=HH 
awaitHH #
_levelServiceHH$ 1
.HH1 2
UpdateLevelHH2 =
(HH= >
UserHH> B
,HHB C
updateLevelDtoHHD R
)HHR S
;HHS T
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
[LL 	

HttpDeleteLL	 
]LL 
[MM 	
RouteMM	 
(MM 
$strMM 
)MM  
]MM  !
publicNN 
asyncNN 
TaskNN 
<NN 
ActionResultNN &
<NN& '
ResponseDTONN' 2
>NN2 3
>NN3 4
DeleteLevelNN5 @
(OO 	
[PP 
	FromRoutePP 
]PP 
GuidPP 
levelIdPP $
)QQ 	
{RR 	
varSS 
responseDtoSS 
=SS 
awaitSS #
_levelServiceSS$ 1
.SS1 2
DeleteLevelSS2 =
(SS= >
UserSS> B
,SSB C
levelIdSSD K
)SSK L
;SSL M
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
}VV 
}WW ∞π
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
]AA8 9
[BB 	
	AuthorizeBB	 
(BB 
RolesBB 
=BB 
StaticUserRolesBB *
.BB* +
AdminInstructorBB+ :
)BB: ;
]BB; <
publicCC 
asyncCC 
TaskCC 
<CC 
ActionResultCC &
<CC& '
ResponseDTOCC' 2
>CC2 3
>CC3 4-
!GetTotalEarnedMoneyInstructorByIdCC5 V
(CCV W
[CCW X
	FromRouteCCX a
]CCa b
GuidCCc g
instructorIdCCh t
)CCt u
{DD 	
varEE 
responseDtoEE 
=EE 
awaitEE #
_instructorServiceEE$ 6
.EE6 7$
GetInstructorEarnedMoneyEE7 O
(EEO P
instructorIdEEP \
)EE\ ]
;EE] ^
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
[II 	
HttpGetII	 
]II 
[JJ 	
RouteJJ	 
(JJ 
$strJJ 7
)JJ7 8
]JJ8 9
[KK 	
	AuthorizeKK	 
(KK 
RolesKK 
=KK 
StaticUserRolesKK *
.KK* +
AdminInstructorKK+ :
)KK: ;
]KK; <
publicLL 
asyncLL 
TaskLL 
<LL 
ActionResultLL &
<LL& '
ResponseDTOLL' 2
>LL2 3
>LL3 4-
!GetTotalPayoutMoneyInstructorByIdLL5 V
(LLV W
[LLW X
	FromRouteLLX a
]LLa b
GuidLLc g
instructorIdLLh t
)LLt u
{MM 	
varNN 
responseDtoNN 
=NN 
awaitNN #
_instructorServiceNN$ 6
.NN6 7$
GetInstructorPayoutMoneyNN7 O
(NNO P
instructorIdNNP \
)NN\ ]
;NN] ^
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
[RR 	
HttpPutRR	 
]RR 
[SS 	
	AuthorizeSS	 
(SS 
RolesSS 
=SS 
StaticUserRolesSS *
.SS* +
AdminInstructorSS+ :
)SS: ;
]SS; <
publicTT 
asyncTT 
TaskTT 
<TT 
ActionResultTT &
<TT& '
ResponseDTOTT' 2
>TT2 3
>TT3 4 
UpdateInstructorByIdTT5 I
(TTI J
[TTJ K
FromBodyTTK S
]TTS T
UpdateInstructorDTOTTU h
instructorDtoTTi v
)TTv w
{UU 	
varVV 
responseDtoVV 
=VV 
awaitVV #
_instructorServiceVV$ 6
.VV6 7

UpdateByIdVV7 A
(VVA B
instructorDtoVVB O
)VVO P
;VVP Q
returnWW 

StatusCodeWW 
(WW 
responseDtoWW )
.WW) *

StatusCodeWW* 4
,WW4 5
responseDtoWW6 A
)WWA B
;WWB C
}XX 	
[ZZ 	
HttpPostZZ	 
]ZZ 
[[[ 	
Route[[	 
([[ 
$str[[ +
)[[+ ,
][[, -
[\\ 	
	Authorize\\	 
(\\ 
Roles\\ 
=\\ 
StaticUserRoles\\ *
.\\* +
Admin\\+ 0
)\\0 1
]\\1 2
public]] 
async]] 
Task]] 
<]] 
ActionResult]] &
<]]& '
ResponseDTO]]' 2
>]]2 3
>]]3 4
AcceptInstructor]]5 E
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
AcceptInstructor__7 G
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
[cc 	
HttpPostcc	 
]cc 
[dd 	
Routedd	 
(dd 
$strdd +
)dd+ ,
]dd, -
[ee 	
	Authorizeee	 
(ee 
Rolesee 
=ee 
StaticUserRolesee *
.ee* +
Adminee+ 0
)ee0 1
]ee1 2
publicff 
asyncff 
Taskff 
<ff 
ActionResultff &
<ff& '
ResponseDTOff' 2
>ff2 3
>ff3 4
RejectInstructorff5 E
(ffE F
[ffF G
	FromRouteffG P
]ffP Q
GuidffR V
instructorIdffW c
)ffc d
{gg 	
varhh 
responseDtohh 
=hh 
awaithh #
_instructorServicehh$ 6
.hh6 7
RejectInstructorhh7 G
(hhG H
UserhhH L
,hhL M
instructorIdhhN Z
)hhZ [
;hh[ \
returnii 

StatusCodeii 
(ii 
responseDtoii )
.ii) *

StatusCodeii* 4
,ii4 5
responseDtoii6 A
)iiA B
;iiB C
}jj 	
[oo 	
HttpGetoo	 
]oo 
[pp 	
Routepp	 
(pp 
$strpp ,
)pp, -
]pp- .
[qq 	
	Authorizeqq	 
(qq 
Rolesqq 
=qq 
StaticUserRolesqq *
.qq* +
AdminInstructorqq+ :
)qq: ;
]qq; <
publicrr 
asyncrr 
Taskrr 
<rr 
ActionResultrr &
<rr& '
ResponseDTOrr' 2
>rr2 3
>rr3 4#
GetAllInstructorCommentrr5 L
(ss 	
[tt 
	FromRoutett 
]tt 
Guidtt 
instructorIdtt )
,tt) *
[uu 
	FromQueryuu 
]uu 
intuu 

pageNumberuu &
=uu' (
$numuu) *
,uu* +
[vv 
	FromQueryvv 
]vv 
intvv 
pageSizevv $
=vv% &
$numvv' )
)ww 	
{xx 	
varyy 
responseDtoyy 
=yy 
awaityy #
_instructorServiceyy$ 6
.yy6 7#
GetAllInstructorCommentyy7 N
(yyN O
instructorIdyyO [
,yy[ \

pageNumberyy] g
,yyg h
pageSizeyyi q
)yyq r
;yyr s
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
[}} 	
HttpPost}}	 
]}} 
[~~ 	
Route~~	 
(~~ 
$str~~ 
)~~ 
]~~ 
[ 	
	Authorize	 
( 
Roles 
= 
StaticUserRoles *
.* +
Admin+ 0
)0 1
]1 2
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
<
ÄÄ 
ActionResult
ÄÄ &
<
ÄÄ& '
ResponseDTO
ÄÄ' 2
>
ÄÄ2 3
>
ÄÄ3 4%
CreateInstructorComment
ÄÄ5 L
(
ÅÅ 	(
CreateInstructorCommentDTO
ÇÇ &%
createInstructorComment
ÇÇ' >
)
ÇÇ> ?
{
ÉÉ 	
var
ÑÑ 
responseDto
ÑÑ 
=
ÑÑ 
await
ÑÑ # 
_instructorService
ÑÑ$ 6
.
ÑÑ6 7%
CreateInstructorComment
ÑÑ7 N
(
ÑÑN O
User
ÑÑO S
,
ÑÑS T%
createInstructorComment
ÑÑU l
)
ÑÑl m
;
ÑÑm n
return
ÖÖ 

StatusCode
ÖÖ 
(
ÖÖ 
responseDto
ÖÖ )
.
ÖÖ) *

StatusCode
ÖÖ* 4
,
ÖÖ4 5
responseDto
ÖÖ6 A
)
ÖÖA B
;
ÖÖB C
}
ÜÜ 	
[
àà 	
HttpPut
àà	 
]
àà 
[
ââ 	
Route
ââ	 
(
ââ 
$str
ââ 
)
ââ 
]
ââ 
[
ää 	
	Authorize
ää	 
(
ää 
Roles
ää 
=
ää 
StaticUserRoles
ää *
.
ää* +
Admin
ää+ 0
)
ää0 1
]
ää1 2
public
ãã 
async
ãã 
Task
ãã 
<
ãã 
ActionResult
ãã &
<
ãã& '
ResponseDTO
ãã' 2
>
ãã2 3
>
ãã3 4%
UpdateInstructorComment
ãã5 L
(
åå 	(
UpdateInstructorCommentDTO
çç &%
updateInstructorComment
çç' >
)
çç> ?
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
UpdateInstructorComment
èè7 N
(
èèN O
User
èèO S
,
èèS T%
updateInstructorComment
èèU l
)
èèl m
;
èèm n
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
ìì 	

HttpDelete
ìì	 
]
ìì 
[
îî 	
Route
îî	 
(
îî 
$str
îî )
)
îî) *
]
îî* +
[
ïï 	
	Authorize
ïï	 
(
ïï 
Roles
ïï 
=
ïï 
StaticUserRoles
ïï *
.
ïï* +
Admin
ïï+ 0
)
ïï0 1
]
ïï1 2
public
ññ 
async
ññ 
Task
ññ 
<
ññ 
ActionResult
ññ &
<
ññ& '
ResponseDTO
ññ' 2
>
ññ2 3
>
ññ3 4%
DeleteInstructorComment
ññ5 L
(
óó 	
[
òò 
	FromRoute
òò 
]
òò 
Guid
òò 
	commentId
òò &
)
ôô 	
{
õõ 	
var
úú 
responseDto
úú 
=
úú 
await
úú # 
_instructorService
úú$ 6
.
úú6 7%
DeleteInstructorComment
úú7 N
(
úúN O
	commentId
úúO X
)
úúX Y
;
úúY Z
return
ùù 

StatusCode
ùù 
(
ùù 
responseDto
ùù )
.
ùù) *

StatusCode
ùù* 4
,
ùù4 5
responseDto
ùù6 A
)
ùùA B
;
ùùB C
}
ûû 	
[
†† 	
HttpPost
††	 
]
†† 
[
°° 	
Route
°°	 
(
°° 
$str
°° .
)
°°. /
]
°°/ 0
[
¢¢ 	
	Authorize
¢¢	 
(
¢¢ 
Roles
¢¢ 
=
¢¢ 
StaticUserRoles
¢¢ *
.
¢¢* +
Admin
¢¢+ 0
)
¢¢0 1
]
¢¢1 2
public
££ 
async
££ 
Task
££ 
<
££ 
ActionResult
££ &
<
££& '
ResponseDTO
££' 2
>
££2 3
>
££3 4
ExportInstructor
££5 E
(
§§ 	
[
•• 
	FromRoute
•• 
]
•• 
int
•• 
month
•• !
,
••! "
[
¶¶ 
	FromRoute
¶¶ 
]
¶¶ 
int
¶¶ 
year
¶¶  
)
ßß 	
{
®® 	
var
©© 
userId
©© 
=
©© 
User
©© 
.
©© 
Claims
©© $
.
©©$ %
FirstOrDefault
©©% 3
(
©©3 4
x
©©4 5
=>
©©6 8
x
©©9 :
.
©©: ;
Type
©©; ?
==
©©@ B

ClaimTypes
©©C M
.
©©M N
NameIdentifier
©©N \
)
©©\ ]
?
©©] ^
.
©©^ _
Value
©©_ d
;
©©d e
BackgroundJob
™™ 
.
™™ 
Enqueue
™™ !
<
™™! " 
IInstructorService
™™" 4
>
™™4 5
(
™™5 6
job
™™6 9
=>
™™: <
job
™™= @
.
™™@ A
ExportInstructors
™™A R
(
™™R S
userId
™™S Y
,
™™Y Z
month
™™[ `
,
™™` a
year
™™b f
)
™™f g
)
™™g h
;
™™h i
return
´´ 
Ok
´´ 
(
´´ 
)
´´ 
;
´´ 
}
¨¨ 	
[
ÆÆ 	
HttpGet
ÆÆ	 
]
ÆÆ 
[
ØØ 	
Route
ØØ	 
(
ØØ 
$str
ØØ $
)
ØØ$ %
]
ØØ% &
[
∞∞ 	
	Authorize
∞∞	 
(
∞∞ 
Roles
∞∞ 
=
∞∞ 
StaticUserRoles
∞∞ *
.
∞∞* +
Admin
∞∞+ 0
)
∞∞0 1
]
∞∞1 2
public
±± 
async
±± 
Task
±± 
<
±± 
ActionResult
±± &
<
±±& '"
ClosedXMLResponseDTO
±±' ;
>
±±; <
>
±±< = 
DownloadInstructor
±±> P
(
≤≤ 	
[
≥≥ 
	FromRoute
≥≥ 
]
≥≥ 
string
≥≥ 
fileName
≥≥ '
)
¥¥ 	
{
µµ 	
var
∂∂ "
closedXmlResponseDto
∂∂ $
=
∂∂% &
await
∂∂' , 
_instructorService
∂∂- ?
.
∂∂? @!
DownloadInstructors
∂∂@ S
(
∂∂S T
fileName
∂∂T \
)
∂∂\ ]
;
∂∂] ^
var
∑∑ 
stream
∑∑ 
=
∑∑ "
closedXmlResponseDto
∑∑ -
.
∑∑- .
Stream
∑∑. 4
;
∑∑4 5
var
∏∏ 
contentType
∏∏ 
=
∏∏ "
closedXmlResponseDto
∏∏ 2
.
∏∏2 3
ContentType
∏∏3 >
;
∏∏> ?
if
∫∫ 
(
∫∫ 
stream
∫∫ 
is
∫∫ 
null
∫∫ 
||
∫∫ !
contentType
∫∫" -
is
∫∫. 0
null
∫∫1 5
)
∫∫5 6
{
ªª 
return
ºº 
NotFound
ºº 
(
ºº  
)
ºº  !
;
ºº! "
}
ΩΩ 
return
øø 
File
øø 
(
øø 
stream
øø 
,
øø 
contentType
øø  +
,
øø+ ,
fileName
øø- 5
)
øø5 6
;
øø6 7
}
¿¿ 	
[
¬¬ 	
HttpGet
¬¬	 
]
¬¬ 
[
√√ 	
Route
√√	 
(
√√ 
$str
√√ 
)
√√ 
]
√√ 
[
ƒƒ 	
	Authorize
ƒƒ	 
(
ƒƒ 
Roles
ƒƒ 
=
ƒƒ 
StaticUserRoles
ƒƒ *
.
ƒƒ* +
Admin
ƒƒ+ 0
)
ƒƒ0 1
]
ƒƒ1 2
public
≈≈ 
async
≈≈ 
Task
≈≈ 
<
≈≈ 
ActionResult
≈≈ &
<
≈≈& '
ResponseDTO
≈≈' 2
>
≈≈2 3
>
≈≈3 4'
GetTopInstructorsByPayout
≈≈5 N
(
∆∆ 	
[
«« 
	FromQuery
«« 
]
«« 
int
«« 
topN
««  
,
««  !
[
»» 
	FromQuery
»» 
]
»» 
int
»» 
?
»» 

filterYear
»» '
,
»»' (
[
…… 
	FromQuery
…… 
]
…… 
int
…… 
?
…… 
filterMonth
…… (
,
……( )
[
   
	FromQuery
   
]
   
int
   
?
   
filterQuarter
   *
)
ÀÀ 	
{
ÃÃ 	
var
ÕÕ 
responseDto
ÕÕ 
=
ÕÕ 
await
ÕÕ #
_paymentService
ÕÕ$ 3
.
ÕÕ3 4'
GetTopInstructorsByPayout
ÕÕ4 M
(
ŒŒ 
topN
œœ 
,
œœ 

filterYear
–– 
,
–– 
filterMonth
—— 
,
—— 
filterQuarter
““ 
)
”” 
;
”” 
return
‘‘ 

StatusCode
‘‘ 
(
‘‘ 
responseDto
‘‘ )
.
‘‘) *

StatusCode
‘‘* 4
,
‘‘4 5
responseDto
‘‘6 A
)
‘‘A B
;
‘‘B C
}
’’ 	
[
◊◊ 	
HttpGet
◊◊	 
]
◊◊ 
[
ÿÿ 	
Route
ÿÿ	 
(
ÿÿ 
$str
ÿÿ 
)
ÿÿ 
]
ÿÿ 
[
ŸŸ 	
	Authorize
ŸŸ	 
(
ŸŸ 
Roles
ŸŸ 
=
ŸŸ 
StaticUserRoles
ŸŸ *
.
ŸŸ* +
Admin
ŸŸ+ 0
)
ŸŸ0 1
]
ŸŸ1 2
public
⁄⁄ 
async
⁄⁄ 
Task
⁄⁄ 
<
⁄⁄ 
ActionResult
⁄⁄ &
<
⁄⁄& '
ResponseDTO
⁄⁄' 2
>
⁄⁄2 3
>
⁄⁄3 4)
GetLeastInstructorsByPayout
⁄⁄5 P
(
€€ 	
[
‹‹ 
	FromQuery
‹‹ 
]
‹‹ 
int
‹‹ 
topN
‹‹  
,
‹‹  !
[
›› 
	FromQuery
›› 
]
›› 
int
›› 
?
›› 

filterYear
›› '
,
››' (
[
ﬁﬁ 
	FromQuery
ﬁﬁ 
]
ﬁﬁ 
int
ﬁﬁ 
?
ﬁﬁ 
filterMonth
ﬁﬁ (
,
ﬁﬁ( )
[
ﬂﬂ 
	FromQuery
ﬂﬂ 
]
ﬂﬂ 
int
ﬂﬂ 
?
ﬂﬂ 
filterQuarter
ﬂﬂ *
)
‡‡ 	
{
·· 	
var
‚‚ 
responseDto
‚‚ 
=
‚‚ 
await
‚‚ #
_paymentService
‚‚$ 3
.
‚‚3 4)
GetLeastInstructorsByPayout
‚‚4 O
(
„„ 
topN
‰‰ 
,
‰‰ 

filterYear
ÂÂ 
,
ÂÂ 
filterMonth
ÊÊ 
,
ÊÊ 
filterQuarter
ÁÁ 
)
ËË 
;
ËË 
return
ÈÈ 

StatusCode
ÈÈ 
(
ÈÈ 
responseDto
ÈÈ )
.
ÈÈ) *

StatusCode
ÈÈ* 4
,
ÈÈ4 5
responseDto
ÈÈ6 A
)
ÈÈA B
;
ÈÈB C
}
ÍÍ 	
}
ÎÎ 
}ÏÏ ±M
pD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\EmailTemplateController.cs
	namespace 	
Cursus
 
. 
LMS 
. 
API 
. 
Controllers $
{		 
[

 
Route

 

(


 
$str

 
)

 
]

 
[ 
ApiController 
] 
[ 
	Authorize 
( 
Roles 
= 
StaticUserRoles &
.& '
Admin' ,
), -
]- .
public 

class #
EmailTemplateController (
:) *
ControllerBase+ 9
{ 
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IEmailService &
_emailService' 4
;4 5
public #
EmailTemplateController &
(& '
IUnitOfWork' 2

unitOfWork3 =
,= >
IEmailService? L
emailServiceM Y
)Y Z
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
_emailService 
= 
emailService (
;( )
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4 
GetAllEmailTemplates5 I
(I J
[ 
	FromQuery 
] 
string 
? 
filterOn  (
,( )
[ 
	FromQuery 
] 
string 
? 
filterQuery  +
,+ ,
[   
	FromQuery   
]   
string   
?   
sortBy    &
,  & '
[!! 
	FromQuery!! 
]!! 
bool!! 
?!! 
isAscending!! )
,!!) *
["" 
	FromQuery"" 
]"" 
int"" 

pageNumber"" &
=""' (
$num"") *
,""* +
[## 
	FromQuery## 
]## 
int## 
pageSize## $
=##% &
$num##' )
)##) *
{$$ 	
var&& 
responseDto&& 
=&& 
await'' 
_emailService'' #
.''# $
GetAll''$ *
(''* +
User''+ /
,''/ 0
filterOn''1 9
,''9 :
filterQuery''; F
,''F G
sortBy''H N
,''N O
isAscending''P [
,''[ \

pageNumber''] g
,''g h
pageSize''i q
)''q r
;''r s
return(( 

StatusCode(( 
((( 
responseDto(( )
.(() *

StatusCode((* 4
,((4 5
responseDto((6 A
)((A B
;((B C
})) 	
[00 	
HttpGet00	 
(00 
$str00 
)00 
]00 
public11 
async11 
Task11 
<11 
ActionResult11 &
<11& '
ResponseDTO11' 2
>112 3
>113 4 
GetEmailTemplateById115 I
(11I J
Guid11J N
id11O Q
)11Q R
{22 	
var33 
emailTemplate33 
=33 
await33  %
_unitOfWork33& 1
.331 2#
EmailTemplateRepository332 I
.33I J
GetAsync33J R
(33R S
x33S T
=>33U W
x33X Y
.33Y Z
Id33Z \
==33] _
id33` b
)33b c
;33c d
if44 
(44 
emailTemplate44 
==44  
null44! %
)44% &
{55 
return66 
NotFound66 
(66  
new66  #
ResponseDTO66$ /
{77 
	IsSuccess88 
=88 
false88  %
,88% &
Message99 
=99 
$str99 <
}:: 
):: 
;:: 
};; 
return== 
Ok== 
(== 
new== 
ResponseDTO== %
{>> 
Result?? 
=?? 
emailTemplate?? &
,??& '
	IsSuccess@@ 
=@@ 
true@@  
,@@  !
MessageAA 
=AA 
$strAA ;
}BB 
)BB 
;BB 
}CC 	
[KK 	
HttpPutKK	 
(KK 
$strKK 
)KK 
]KK 
publicLL 
asyncLL 
TaskLL 
<LL 
ActionResultLL &
<LL& '
ResponseDTOLL' 2
>LL2 3
>LL3 4
UpdateEmailTemplateLL5 H
(LLH I
GuidLLI M
idLLN P
,LLP Q"
UpdateEmailTemplateDTOMM ""
updateEmailTemplateDTOMM# 9
)MM9 :
{NN 	
varOO 
emailTemplateOO 
=OO 
awaitOO  %
_unitOfWorkOO& 1
.OO1 2#
EmailTemplateRepositoryOO2 I
.OOI J
GetAsyncOOJ R
(OOR S
xOOS T
=>OOU W
xOOX Y
.OOY Z
IdOOZ \
==OO] _
idOO` b
)OOb c
;OOc d
ifQQ 
(QQ 
emailTemplateQQ 
==QQ  
nullQQ! %
)QQ% &
{RR 
returnSS 
NotFoundSS 
(SS  
newSS  #
ResponseDTOSS$ /
{TT 
	IsSuccessUU 
=UU 
falseUU  %
,UU% &
MessageVV 
=VV 
$strVV <
}WW 
)WW 
;WW 
}XX 
emailTemplate[[ 
.[[ 
TemplateName[[ &
=[[' ("
updateEmailTemplateDTO[[) ?
.[[? @
TemplateName[[@ L
;[[L M
emailTemplate\\ 
.\\ 

SenderName\\ $
=\\% &"
updateEmailTemplateDTO\\' =
.\\= >

SenderName\\> H
;\\H I
emailTemplate]] 
.]] 
SenderEmail]] %
=]]& '"
updateEmailTemplateDTO]]( >
.]]> ?
SenderEmail]]? J
;]]J K
emailTemplate^^ 
.^^ 
Category^^ "
=^^# $"
updateEmailTemplateDTO^^% ;
.^^; <
Category^^< D
;^^D E
emailTemplate__ 
.__ 
SubjectLine__ %
=__& '"
updateEmailTemplateDTO__( >
.__> ?
SubjectLine__? J
;__J K
emailTemplate`` 
.`` 
PreHeaderText`` '
=``( )"
updateEmailTemplateDTO``* @
.``@ A
PreHeaderText``A N
;``N O
emailTemplateaa 
.aa 
PersonalizationTagsaa -
=aa. /"
updateEmailTemplateDTOaa0 F
.aaF G
PersonalizationTagsaaG Z
;aaZ [
emailTemplatebb 
.bb 
BodyContentbb %
=bb& '"
updateEmailTemplateDTObb( >
.bb> ?
BodyContentbb? J
;bbJ K
emailTemplatecc 
.cc 
FooterContentcc '
=cc( )"
updateEmailTemplateDTOcc* @
.cc@ A
FooterContentccA N
;ccN O
emailTemplatedd 
.dd 
CallToActiondd &
=dd' ("
updateEmailTemplateDTOdd) ?
.dd? @
CallToActiondd@ L
;ddL M
emailTemplateee 
.ee 
Languageee "
=ee# $"
updateEmailTemplateDTOee% ;
.ee; <
Languageee< D
;eeD E
emailTemplateff 
.ff 
RecipientTypeff '
=ff( )"
updateEmailTemplateDTOff* @
.ff@ A
RecipientTypeffA N
;ffN O
_unitOfWorkhh 
.hh #
EmailTemplateRepositoryhh /
.hh/ 0
Updatehh0 6
(hh6 7
emailTemplatehh7 D
)hhD E
;hhE F
awaitii 
_unitOfWorkii 
.ii 
	SaveAsyncii '
(ii' (
)ii( )
;ii) *
returnkk 
Okkk 
(kk 
newkk 
ResponseDTOkk %
{ll 
Resultmm 
=mm 
emailTemplatemm &
,mm& '
	IsSuccessnn 
=nn 
truenn  
,nn  !
Messageoo 
=oo 
$stroo >
}pp 
)pp 
;pp 
}qq 	
[xx 	

HttpDeletexx	 
(xx 
$strxx 
)xx  
]xx  !
publicyy 
ActionResultyy 
<yy 
ResponseDTOyy '
>yy' (
DeleteEmailTemplateyy) <
(yy< =
Guidyy= A
idyyB D
)yyD E
{zz 	
return{{ 

BadRequest{{ 
({{ 
new{{ !
ResponseDTO{{" -
{|| 
	IsSuccess}} 
=}} 
false}} !
,}}! "
Message~~ 
=~~ 
$str~~ C
} 
) 
; 
}
ÄÄ 	
[
áá 	
HttpPost
áá	 
]
áá 
public
àà 
ActionResult
àà 
<
àà 
ResponseDTO
àà '
>
àà' (!
CreateEmailTemplate
àà) <
(
àà< =$
CreateEmailTemplateDTO
àà= S$
createEmailTemplateDTO
ààT j
)
ààj k
{
ââ 	
return
ää 

BadRequest
ää 
(
ää 
new
ää !
ResponseDTO
ää" -
{
ãã 
	IsSuccess
åå 
=
åå 
false
åå !
,
åå! "
Message
çç 
=
çç 
$str
çç B
}
éé 
)
éé 
;
éé 
}
èè 	
}
ÕÕ 
}ŒŒ ÕÕ
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
] 
[ 	
	Authorize	 
] 
public   
async   
Task   
<   
ActionResult   &
<  & '
ResponseDTO  ' 2
>  2 3
>  3 4
GetCourseVersions  5 F
(!! 	
["" 
	FromQuery"" 
]"" 
Guid"" 
?"" 
courseId"" &
,""& '
[## 
	FromQuery## 
]## 
string## 
?## 
filterOn##  (
,##( )
[$$ 
	FromQuery$$ 
]$$ 
string$$ 
?$$ 
filterQuery$$  +
,$$+ ,
[%% 
	FromQuery%% 
]%% 
string%% 
?%% 
sortBy%%  &
,%%& '
[&& 
	FromQuery&& 
]&& 
bool&& 
?&& 
isAscending&& )
,&&) *
['' 
	FromQuery'' 
]'' 
int'' 

pageNumber'' &
=''' (
$num'') *
,''* +
[(( 
	FromQuery(( 
](( 
int(( 
pageSize(( $
=((% &
$num((' (
))) 	
{** 	
var++ 
responseDto++ 
=++ 
await++ #!
_courseVersionService++$ 9
.++9 :
GetCourseVersions++: K
(,, 
User-- 
,-- 
courseId.. 
,.. 
filterOn// 
,// 
filterQuery00 
,00 
sortBy11 
,11 
isAscending22 
,22 

pageNumber33 
,33 
pageSize44 
)55 
;55 
return77 

StatusCode77 
(77 
responseDto77 )
.77) *

StatusCode77* 4
,774 5
responseDto776 A
)77A B
;77B C
}88 	
[:: 	
HttpGet::	 
]:: 
[;; 	
Route;;	 
(;; 
$str;;  
);;  !
];;! "
[<< 	
	Authorize<<	 
]<< 
public== 
async== 
Task== 
<== 
ActionResult== &
<==& '
ResponseDTO==' 2
>==2 3
>==3 4
GetCourseVersion==5 E
(==E F
[==F G
	FromRoute==G P
]==P Q
Guid==R V
courseId==W _
)==_ `
{>> 	
var?? 
responseDto?? 
=?? 
await?? #!
_courseVersionService??$ 9
.??9 :
GetCourseVersion??: J
(??J K
User??K O
,??O P
courseId??Q Y
)??Y Z
;??Z [
return@@ 

StatusCode@@ 
(@@ 
responseDto@@ )
.@@) *

StatusCode@@* 4
,@@4 5
responseDto@@6 A
)@@A B
;@@B C
}AA 	
[CC 	
HttpPostCC	 
]CC 
[DD 	
RouteDD	 
(DD 
$strDD 
)DD 
]DD 
[EE 	
	AuthorizeEE	 
(EE 
RolesEE 
=EE 
StaticUserRolesEE *
.EE* +

InstructorEE+ 5
)EE5 6
]EE6 7
publicFF 
asyncFF 
TaskFF 
<FF 
ActionResultFF &
<FF& '
ResponseDTOFF' 2
>FF2 3
>FF3 4"
CreateCourseAndVersionFF5 K
(GG 	(
CreateNewCourseAndVersionDTOHH ((
createNewCourseAndVersionDtoHH) E
)II 	
{JJ 	
varKK 
responseDtoKK 
=KK 
awaitKK #!
_courseVersionServiceKK$ 9
.KK9 :"
CreateCourseAndVersionKK: P
(KKP Q
UserKKQ U
,KKU V(
createNewCourseAndVersionDtoKKW s
)KKs t
;KKt u
returnLL 

StatusCodeLL 
(LL 
responseDtoLL )
.LL) *

StatusCodeLL* 4
,LL4 5
responseDtoLL6 A
)LLA B
;LLB C
}MM 	
[OO 	
HttpPostOO	 
]OO 
[PP 	
RoutePP	 
(PP 
$strPP 
)PP 
]PP 
[QQ 	
	AuthorizeQQ	 
(QQ 
RolesQQ 
=QQ 
StaticUserRolesQQ *
.QQ* +

InstructorQQ+ 5
)QQ5 6
]QQ6 7
publicRR 
asyncRR 
TaskRR 
<RR 
ActionResultRR &
<RR& '
ResponseDTORR' 2
>RR2 3
>RR3 4
CloneCourseVersionRR5 G
(SS 	
[TT 
FromBodyTT 
]TT !
CloneCourseVersionDTOTT ,!
cloneCourseVersionDtoTT- B
)UU 	
{VV 	
varWW 
responseDtoWW 
=WW 
awaitWW #!
_courseVersionServiceWW$ 9
.WW9 :
CloneCourseVersionWW: L
(WWL M
UserWWM Q
,WWQ R!
cloneCourseVersionDtoWWS h
)WWh i
;WWi j
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
[[[ 	
HttpPut[[	 
][[ 
[\\ 	
Route\\	 
(\\ 
$str\\ 
)\\ 
]\\ 
[]] 	
	Authorize]]	 
(]] 
Roles]] 
=]] 
StaticUserRoles]] *
.]]* +

Instructor]]+ 5
)]]5 6
]]]6 7
public^^ 
async^^ 
Task^^ 
<^^ 
ActionResult^^ &
<^^& '
ResponseDTO^^' 2
>^^2 3
>^^3 4
EditCourseVersion^^5 F
(__ 	
[`` 
FromBody`` 
]``  
EditCourseVersionDTO`` + 
editCourseVersionDto``, @
)``@ A
{aa 	
varbb 
responseDtobb 
=bb 
awaitbb #!
_courseVersionServicebb$ 9
.bb9 :
EditCourseVersionbb: K
(bbK L
UserbbL P
,bbP Q 
editCourseVersionDtobbR f
)bbf g
;bbg h
returncc 

StatusCodecc 
(cc 
responseDtocc )
.cc) *

StatusCodecc* 4
,cc4 5
responseDtocc6 A
)ccA B
;ccB C
}dd 	
[ff 	

HttpDeleteff	 
]ff 
[gg 	
Routegg	 
(gg 
$strgg '
)gg' (
]gg( )
[hh 	
	Authorizehh	 
(hh 
Roleshh 
=hh 
StaticUserRoleshh *
.hh* +

Instructorhh+ 5
)hh5 6
]hh6 7
publicii 
asyncii 
Taskii 
<ii 
ActionResultii &
<ii& '
ResponseDTOii' 2
>ii2 3
>ii3 4
RemoveCourseVersionii5 H
(iiH I
[iiI J
	FromRouteiiJ S
]iiS T
GuidiiU Y
courseIdiiZ b
)iib c
{jj 	
varkk 
responseDtokk 
=kk 
awaitkk #!
_courseVersionServicekk$ 9
.kk9 :
RemoveCourseVersionkk: M
(kkM N
UserkkN R
,kkR S
courseIdkkT \
)kk\ ]
;kk] ^
returnll 

StatusCodell 
(ll 
responseDtoll )
.ll) *

StatusCodell* 4
,ll4 5
responseDtoll6 A
)llA B
;llB C
}mm 	
[oo 	
HttpPostoo	 
]oo 
[pp 	
Routepp	 
(pp 
$strpp '
)pp' (
]pp( )
[qq 	
	Authorizeqq	 
(qq 
Rolesqq 
=qq 
StaticUserRolesqq *
.qq* +
Adminqq+ 0
)qq0 1
]qq1 2
publicrr 
asyncrr 
Taskrr 
<rr 
ActionResultrr &
<rr& '
ResponseDTOrr' 2
>rr2 3
>rr3 4
AcceptCourseVersionrr5 H
(rrH I
[rrI J
	FromRouterrJ S
]rrS T
GuidrrU Y
courseIdrrZ b
)rrb c
{ss 	
vartt 
responseDtott 
=tt 
awaittt #!
_courseVersionServicett$ 9
.tt9 :
AcceptCourseVersiontt: M
(ttM N
UserttN R
,ttR S
courseIdttT \
)tt\ ]
;tt] ^
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
[xx 	
HttpPostxx	 
]xx 
[yy 	
Routeyy	 
(yy 
$stryy '
)yy' (
]yy( )
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
RejectCourseVersion{{5 H
({{H I
[{{I J
	FromRoute{{J S
]{{S T
Guid{{U Y
courseId{{Z b
){{b c
{|| 	
var}} 
responseDto}} 
=}} 
await}} #!
_courseVersionService}}$ 9
.}}9 :
RejectCourseVersion}}: M
(}}M N
User}}N R
,}}R S
courseId}}T \
)}}\ ]
;}}] ^
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
ÅÅ 	
HttpPost
ÅÅ	 
]
ÅÅ 
[
ÇÇ 	
Route
ÇÇ	 
(
ÇÇ 
$str
ÇÇ '
)
ÇÇ' (
]
ÇÇ( )
[
ÉÉ 	
	Authorize
ÉÉ	 
(
ÉÉ 
Roles
ÉÉ 
=
ÉÉ 
StaticUserRoles
ÉÉ *
.
ÉÉ* +

Instructor
ÉÉ+ 5
)
ÉÉ5 6
]
ÉÉ6 7
public
ÑÑ 
async
ÑÑ 
Task
ÑÑ 
<
ÑÑ 
ActionResult
ÑÑ &
<
ÑÑ& '
ResponseDTO
ÑÑ' 2
>
ÑÑ2 3
>
ÑÑ3 4!
SubmitCourseVersion
ÑÑ5 H
(
ÑÑH I
[
ÑÑI J
	FromRoute
ÑÑJ S
]
ÑÑS T
Guid
ÑÑU Y
courseId
ÑÑZ b
)
ÑÑb c
{
ÖÖ 	
var
ÜÜ 
responseDto
ÜÜ 
=
ÜÜ 
await
ÜÜ ##
_courseVersionService
ÜÜ$ 9
.
ÜÜ9 :!
SubmitCourseVersion
ÜÜ: M
(
ÜÜM N
User
ÜÜN R
,
ÜÜR S
courseId
ÜÜT \
)
ÜÜ\ ]
;
ÜÜ] ^
return
áá 

StatusCode
áá 
(
áá 
responseDto
áá )
.
áá) *

StatusCode
áá* 4
,
áá4 5
responseDto
áá6 A
)
ááA B
;
ááB C
}
àà 	
[
ää 	
HttpPost
ää	 
]
ää 
[
ãã 	
Route
ãã	 
(
ãã 
$str
ãã &
)
ãã& '
]
ãã' (
[
åå 	
	Authorize
åå	 
(
åå 
Roles
åå 
=
åå 
StaticUserRoles
åå *
.
åå* +

Instructor
åå+ 5
)
åå5 6
]
åå6 7
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
çç3 4 
MergeCourseVersion
çç5 G
(
ççG H
[
ççH I
	FromRoute
ççI R
]
ççR S
Guid
ççT X
courseId
ççY a
)
çça b
{
éé 	
var
èè 
responseDto
èè 
=
èè 
await
èè ##
_courseVersionService
èè$ 9
.
èè9 : 
MergeCourseVersion
èè: L
(
èèL M
User
èèM Q
,
èèQ R
courseId
èèS [
)
èè[ \
;
èè\ ]
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
îî 2
)
îî2 3
]
îî3 4
[
ïï 	
	Authorize
ïï	 
(
ïï 
Roles
ïï 
=
ïï 
StaticUserRoles
ïï *
.
ïï* +

Instructor
ïï+ 5
)
ïï5 6
]
ïï6 7
public
ññ 
async
ññ 
Task
ññ 
<
ññ 
ActionResult
ññ &
<
ññ& '
ResponseDTO
ññ' 2
>
ññ2 3
>
ññ3 4+
UploadCourseVersionBackground
ññ5 R
(
óó 	
[
òò 
	FromRoute
òò 
]
òò 
Guid
òò 
courseVersionId
òò ,
,
òò, -.
 UploadCourseVersionBackgroundImg
ôô ,.
 uploadCourseVersionBackgroundImg
ôô- M
)
öö 	
{
õõ 	
var
úú 
responseDto
úú 
=
úú 
await
ùù #
_courseVersionService
ùù +
.
ùù+ ,.
 UploadCourseVersionBackgroundImg
ùù, L
(
ûû 
User
üü 
,
üü 
courseVersionId
†† #
,
††# $.
 uploadCourseVersionBackgroundImg
°° 4
)
¢¢ 
;
¢¢ 
return
££ 

StatusCode
££ 
(
££ 
responseDto
££ )
.
££) *

StatusCode
££* 4
,
££4 5
responseDto
££6 A
)
££A B
;
££B C
}
§§ 	
[
¶¶ 	
HttpGet
¶¶	 
]
¶¶ 
[
ßß 	
Route
ßß	 
(
ßß 
$str
ßß 2
)
ßß2 3
]
ßß3 4
public
®® 
async
®® 
Task
®® 
<
®® 
ActionResult
®® &
>
®®& ',
DisplayCourseVersionBackground
®®( F
(
©© 	
[
™™ 
	FromRoute
™™ 
]
™™ 
Guid
™™ 
courseVersionId
™™ ,
)
´´ 	
{
¨¨ 	
var
≠≠ 
responseDto
≠≠ 
=
≠≠ 
await
≠≠ ##
_courseVersionService
≠≠$ 9
.
≠≠9 :/
!DisplayCourseVersionBackgroundImg
≠≠: [
(
≠≠[ \
User
≠≠\ `
,
≠≠` a
courseVersionId
≠≠b q
)
≠≠q r
;
≠≠r s
if
ÆÆ 
(
ÆÆ 
responseDto
ÆÆ 
is
ÆÆ 
null
ÆÆ #
)
ÆÆ# $
{
ØØ 
return
∞∞ 
null
∞∞ 
;
∞∞ 
}
±± 
return
≥≥ 
File
≥≥ 
(
≥≥ 
responseDto
≥≥ #
,
≥≥# $
$str
≥≥% 0
)
≥≥0 1
;
≥≥1 2
}
¥¥ 	
[
∫∫ 	
HttpGet
∫∫	 
]
∫∫ 
[
ªª 	
Route
ªª	 
(
ªª 
$str
ªª 
)
ªª 
]
ªª 
[
ºº 	
	Authorize
ºº	 
(
ºº 
Roles
ºº 
=
ºº 
StaticUserRoles
ºº *
.
ºº* +
AdminInstructor
ºº+ :
)
ºº: ;
]
ºº; <
public
ΩΩ 
async
ΩΩ 
Task
ΩΩ 
<
ΩΩ 
ActionResult
ΩΩ &
<
ΩΩ& '
ResponseDTO
ΩΩ' 2
>
ΩΩ2 3
>
ΩΩ3 4'
GetCourseVersionsComments
ΩΩ5 N
(
ææ 	
[
øø 
	FromQuery
øø 
]
øø 
[
øø 
Required
øø !
]
øø! "
Guid
øø# '
courseVersionId
øø( 7
,
øø7 8
[
¿¿ 
	FromQuery
¿¿ 
]
¿¿ 
string
¿¿ 
?
¿¿ 
filterOn
¿¿  (
,
¿¿( )
[
¡¡ 
	FromQuery
¡¡ 
]
¡¡ 
string
¡¡ 
?
¡¡ 
filterQuery
¡¡  +
,
¡¡+ ,
[
¬¬ 
	FromQuery
¬¬ 
]
¬¬ 
string
¬¬ 
?
¬¬ 
sortBy
¬¬  &
,
¬¬& '
[
√√ 
	FromQuery
√√ 
]
√√ 
int
√√ 

pageNumber
√√ &
=
√√' (
$num
√√) *
,
√√* +
[
ƒƒ 
	FromQuery
ƒƒ 
]
ƒƒ 
int
ƒƒ 
pageSize
ƒƒ $
=
ƒƒ% &
$num
ƒƒ' )
)
≈≈ 	
{
∆∆ 	
var
«« 
responseDto
«« 
=
«« 
await
«« ##
_courseVersionService
««$ 9
.
««9 :'
GetCourseVersionsComments
««: S
(
»» 
User
…… 
,
…… 
courseVersionId
   
,
    
filterOn
ÀÀ 
,
ÀÀ 
filterQuery
ÃÃ 
,
ÃÃ 
sortBy
ÕÕ 
,
ÕÕ 

pageNumber
ŒŒ 
,
ŒŒ 
pageSize
œœ 
)
–– 
;
–– 
return
““ 

StatusCode
““ 
(
““ 
responseDto
““ )
.
““) *

StatusCode
““* 4
,
““4 5
responseDto
““6 A
)
““A B
;
““B C
}
”” 	
[
’’ 	
HttpGet
’’	 
]
’’ 
[
÷÷ 	
Route
÷÷	 
(
÷÷ 
$str
÷÷ )
)
÷÷) *
]
÷÷* +
[
◊◊ 	
	Authorize
◊◊	 
(
◊◊ 
Roles
◊◊ 
=
◊◊ 
StaticUserRoles
◊◊ *
.
◊◊* +
AdminInstructor
◊◊+ :
)
◊◊: ;
]
◊◊; <
public
ÿÿ 
async
ÿÿ 
Task
ÿÿ 
<
ÿÿ 
ActionResult
ÿÿ &
<
ÿÿ& '
ResponseDTO
ÿÿ' 2
>
ÿÿ2 3
>
ÿÿ3 4%
GetCourseVersionComment
ÿÿ5 L
(
ÿÿL M
[
ÿÿM N
	FromRoute
ÿÿN W
]
ÿÿW X
Guid
ÿÿY ]
	commentId
ÿÿ^ g
)
ÿÿg h
{
ŸŸ 	
var
⁄⁄ 
responseDto
⁄⁄ 
=
⁄⁄ 
await
⁄⁄ ##
_courseVersionService
⁄⁄$ 9
.
⁄⁄9 :%
GetCourseVersionComment
⁄⁄: Q
(
⁄⁄Q R
User
⁄⁄R V
,
⁄⁄V W
	commentId
⁄⁄X a
)
⁄⁄a b
;
⁄⁄b c
return
€€ 

StatusCode
€€ 
(
€€ 
responseDto
€€ )
.
€€) *

StatusCode
€€* 4
,
€€4 5
responseDto
€€6 A
)
€€A B
;
€€B C
}
‹‹ 	
[
ﬁﬁ 	
HttpPost
ﬁﬁ	 
]
ﬁﬁ 
[
ﬂﬂ 	
Route
ﬂﬂ	 
(
ﬂﬂ 
$str
ﬂﬂ 
)
ﬂﬂ 
]
ﬂﬂ 
[
‡‡ 	
	Authorize
‡‡	 
(
‡‡ 
Roles
‡‡ 
=
‡‡ 
StaticUserRoles
‡‡ *
.
‡‡* +
Admin
‡‡+ 0
)
‡‡0 1
]
‡‡1 2
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
··3 4(
CreateCourseVersionComment
··5 O
(
‚‚ 	,
CreateCourseVersionCommentsDTO
„„ *,
createCourseVersionCommentsDto
„„+ I
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
ÁÁ #
_courseVersionService
ÁÁ +
.
ÁÁ+ ,(
CreateCourseVersionComment
ÁÁ, F
(
ÁÁF G
User
ÁÁG K
,
ÁÁK L,
createCourseVersionCommentsDto
ÁÁM k
)
ÁÁk l
;
ÁÁl m
return
ËË 

StatusCode
ËË 
(
ËË 
responseDto
ËË )
.
ËË) *

StatusCode
ËË* 4
,
ËË4 5
responseDto
ËË6 A
)
ËËA B
;
ËËB C
}
ÈÈ 	
[
ÎÎ 	
HttpPut
ÎÎ	 
]
ÎÎ 
[
ÏÏ 	
Route
ÏÏ	 
(
ÏÏ 
$str
ÏÏ 
)
ÏÏ 
]
ÏÏ 
[
ÌÌ 	
	Authorize
ÌÌ	 
(
ÌÌ 
Roles
ÌÌ 
=
ÌÌ 
StaticUserRoles
ÌÌ *
.
ÌÌ* +
Admin
ÌÌ+ 0
)
ÌÌ0 1
]
ÌÌ1 2
public
ÓÓ 
async
ÓÓ 
Task
ÓÓ 
<
ÓÓ 
ActionResult
ÓÓ &
<
ÓÓ& '
ResponseDTO
ÓÓ' 2
>
ÓÓ2 3
>
ÓÓ3 4&
EditCourseVersionComment
ÓÓ5 M
(
ÔÔ 	*
EditCourseVersionCommentsDTO
 (*
editCourseVersionCommentsDto
) E
)
ÒÒ 	
{
ÚÚ 	
var
ÛÛ 
responseDto
ÛÛ 
=
ÛÛ 
await
ÛÛ ##
_courseVersionService
ÛÛ$ 9
.
ÛÛ9 :&
EditCourseVersionComment
ÛÛ: R
(
ÛÛR S
User
ÛÛS W
,
ÛÛW X*
editCourseVersionCommentsDto
ÛÛY u
)
ÛÛu v
;
ÛÛv w
return
ÙÙ 

StatusCode
ÙÙ 
(
ÙÙ 
responseDto
ÙÙ )
.
ÙÙ) *

StatusCode
ÙÙ* 4
,
ÙÙ4 5
responseDto
ÙÙ6 A
)
ÙÙA B
;
ÙÙB C
}
ıı 	
[
˜˜ 	

HttpDelete
˜˜	 
]
˜˜ 
[
¯¯ 	
Route
¯¯	 
(
¯¯ 
$str
¯¯ )
)
¯¯) *
]
¯¯* +
[
˘˘ 	
	Authorize
˘˘	 
(
˘˘ 
Roles
˘˘ 
=
˘˘ 
StaticUserRoles
˘˘ *
.
˘˘* +
Admin
˘˘+ 0
)
˘˘0 1
]
˘˘1 2
public
˙˙ 
async
˙˙ 
Task
˙˙ 
<
˙˙ 
ActionResult
˙˙ &
<
˙˙& '
ResponseDTO
˙˙' 2
>
˙˙2 3
>
˙˙3 4(
RemoveCourseVersionComment
˙˙5 O
(
˙˙O P
[
˚˚ 
	FromRoute
˚˚ 
]
˚˚ 
Guid
˚˚ 
	commentId
˚˚ &
)
˚˚& '
{
¸¸ 	
var
˝˝ 
responseDto
˝˝ 
=
˝˝ 
await
˛˛ #
_courseVersionService
˛˛ +
.
˛˛+ ,(
RemoveCourseVersionComment
˛˛, F
(
˛˛F G
User
˛˛G K
,
˛˛K L
	commentId
˛˛M V
)
˛˛V W
;
˛˛W X
return
ˇˇ 

StatusCode
ˇˇ 
(
ˇˇ 
responseDto
ˇˇ )
.
ˇˇ) *

StatusCode
ˇˇ* 4
,
ˇˇ4 5
responseDto
ˇˇ6 A
)
ˇˇA B
;
ˇˇB C
}
ÄÄ 	
[
ÜÜ 	
HttpGet
ÜÜ	 
]
ÜÜ 
[
áá 	
Route
áá	 
(
áá 
$str
áá 
)
áá 
]
áá 
[
àà 	
	Authorize
àà	 
]
àà 
public
ââ 
async
ââ 
Task
ââ 
<
ââ 
ActionResult
ââ &
<
ââ& '
ResponseDTO
ââ' 2
>
ââ2 3
>
ââ3 4
GetCourseSections
ââ5 F
(
ää 	
[
ãã 
	FromQuery
ãã 
]
ãã 
[
ãã 
Required
ãã !
]
ãã! "
Guid
ãã# '
?
ãã' (
courseVersionId
ãã) 8
,
ãã8 9
[
åå 
	FromQuery
åå 
]
åå 
string
åå 
?
åå 
filterOn
åå  (
,
åå( )
[
çç 
	FromQuery
çç 
]
çç 
string
çç 
?
çç 
filterQuery
çç  +
,
çç+ ,
[
éé 
	FromQuery
éé 
]
éé 
string
éé 
?
éé 
sortBy
éé  &
,
éé& '
[
èè 
	FromQuery
èè 
]
èè 
bool
èè 
?
èè 
isAscending
èè )
,
èè) *
[
êê 
	FromQuery
êê 
]
êê 
int
êê 

pageNumber
êê &
=
êê' (
$num
êê) *
,
êê* +
[
ëë 
	FromQuery
ëë 
]
ëë 
int
ëë 
pageSize
ëë $
=
ëë% &
$num
ëë' (
)
íí 	
{
ìì 	
var
îî 
responseDto
îî 
=
îî 
await
îî #*
_courseSectionVersionService
îî$ @
.
îî@ A
GetCourseSections
îîA R
(
ïï 
User
ññ 
,
ññ 
courseVersionId
óó 
,
óó  
filterOn
òò 
,
òò 
filterQuery
ôô 
,
ôô 
sortBy
öö 
,
öö 

pageNumber
õõ 
,
õõ 
pageSize
úú 
)
ùù 
;
ùù 
return
üü 

StatusCode
üü 
(
üü 
responseDto
üü )
.
üü) *

StatusCode
üü* 4
,
üü4 5
responseDto
üü6 A
)
üüA B
;
üüB C
}
†† 	
[
££ 	
HttpGet
££	 
]
££ 
[
§§ 	
Route
§§	 
(
§§ 
$str
§§ )
)
§§) *
]
§§* +
[
•• 	
	Authorize
••	 
]
•• 
public
¶¶ 
async
¶¶ 
Task
¶¶ 
<
¶¶ 
ActionResult
¶¶ &
<
¶¶& '
ResponseDTO
¶¶' 2
>
¶¶2 3
>
¶¶3 4
GetCourseSection
¶¶5 E
(
¶¶E F
[
¶¶F G
	FromRoute
¶¶G P
]
¶¶P Q
Guid
¶¶R V
	sectionId
¶¶W `
)
¶¶` a
{
ßß 	
var
®® 
responseDto
®® 
=
®® 
await
®® #*
_courseSectionVersionService
®®$ @
.
®®@ A
GetCourseSection
®®A Q
(
®®Q R
User
®®R V
,
®®V W
	sectionId
®®X a
)
®®a b
;
®®b c
return
©© 

StatusCode
©© 
(
©© 
responseDto
©© )
.
©©) *

StatusCode
©©* 4
,
©©4 5
responseDto
©©6 A
)
©©A B
;
©©B C
}
™™ 	
[
¨¨ 	
HttpPost
¨¨	 
]
¨¨ 
[
≠≠ 	
Route
≠≠	 
(
≠≠ 
$str
≠≠ 
)
≠≠ 
]
≠≠ 
[
ÆÆ 	
	Authorize
ÆÆ	 
(
ÆÆ 
Roles
ÆÆ 
=
ÆÆ 
StaticUserRoles
ÆÆ *
.
ÆÆ* +

Instructor
ÆÆ+ 5
)
ÆÆ5 6
]
ÆÆ6 7
public
ØØ 
async
ØØ 
Task
ØØ 
<
ØØ 
ActionResult
ØØ &
<
ØØ& '
ResponseDTO
ØØ' 2
>
ØØ2 3
>
ØØ3 4!
CreateCourseSection
ØØ5 H
(
∞∞ 	+
CreateCourseSectionVersionDTO
±± )+
createCourseSectionVersionDto
±±* G
)
≤≤ 	
{
≥≥ 	
var
¥¥ 
responseDto
¥¥ 
=
¥¥ 
await
µµ *
_courseSectionVersionService
µµ 2
.
µµ2 3!
CreateCourseSection
µµ3 F
(
µµF G
User
µµG K
,
µµK L+
createCourseSectionVersionDto
µµM j
)
µµj k
;
µµk l
return
∂∂ 

StatusCode
∂∂ 
(
∂∂ 
responseDto
∂∂ )
.
∂∂) *

StatusCode
∂∂* 4
,
∂∂4 5
responseDto
∂∂6 A
)
∂∂A B
;
∂∂B C
}
∑∑ 	
[
ππ 	
HttpPut
ππ	 
]
ππ 
[
∫∫ 	
Route
∫∫	 
(
∫∫ 
$str
∫∫ 
)
∫∫ 
]
∫∫ 
[
ªª 	
	Authorize
ªª	 
(
ªª 
Roles
ªª 
=
ªª 
StaticUserRoles
ªª *
.
ªª* +

Instructor
ªª+ 5
)
ªª5 6
]
ªª6 7
public
ºº 
async
ºº 
Task
ºº 
<
ºº 
ActionResult
ºº &
<
ºº& '
ResponseDTO
ºº' 2
>
ºº2 3
>
ºº3 4
EditCourseSection
ºº5 F
(
ΩΩ 	)
EditCourseSectionVersionDTO
ææ '+
createCourseSectionVersionDto
ææ( E
)
øø 	
{
¿¿ 	
var
¡¡ 
responseDto
¡¡ 
=
¡¡ 
await
¡¡ #*
_courseSectionVersionService
¡¡$ @
.
¡¡@ A
EditCourseSection
¡¡A R
(
¡¡R S
User
¡¡S W
,
¡¡W X+
createCourseSectionVersionDto
¡¡Y v
)
¡¡v w
;
¡¡w x
return
¬¬ 

StatusCode
¬¬ 
(
¬¬ 
responseDto
¬¬ )
.
¬¬) *

StatusCode
¬¬* 4
,
¬¬4 5
responseDto
¬¬6 A
)
¬¬A B
;
¬¬B C
}
√√ 	
[
≈≈ 	

HttpDelete
≈≈	 
]
≈≈ 
[
∆∆ 	
Route
∆∆	 
(
∆∆ 
$str
∆∆ $
)
∆∆$ %
]
∆∆% &
[
«« 	
	Authorize
««	 
(
«« 
Roles
«« 
=
«« 
StaticUserRoles
«« *
.
««* +

Instructor
««+ 5
)
««5 6
]
««6 7
public
»» 
async
»» 
Task
»» 
<
»» 
ActionResult
»» &
<
»»& '
ResponseDTO
»»' 2
>
»»2 3
>
»»3 4!
DeleteCourseSection
»»5 H
(
…… 	
[
   
	FromRoute
   
]
   
Guid
   
	sectionId
   &
)
ÀÀ 	
{
ÃÃ 	
var
ÕÕ 
responseDto
ÕÕ 
=
ÕÕ 
await
ŒŒ *
_courseSectionVersionService
ŒŒ 2
.
ŒŒ2 3!
RemoveCourseSection
ŒŒ3 F
(
ŒŒF G
User
ŒŒG K
,
ŒŒK L
	sectionId
ŒŒM V
)
ŒŒV W
;
ŒŒW X
return
œœ 

StatusCode
œœ 
(
œœ 
responseDto
œœ )
.
œœ) *

StatusCode
œœ* 4
,
œœ4 5
responseDto
œœ6 A
)
œœA B
;
œœB C
}
–– 	
[
÷÷ 	
HttpGet
÷÷	 
]
÷÷ 
[
◊◊ 	
Route
◊◊	 
(
◊◊ 
$str
◊◊  
)
◊◊  !
]
◊◊! "
[
ÿÿ 	
	Authorize
ÿÿ	 
]
ÿÿ 
public
ŸŸ 
async
ŸŸ 
Task
ŸŸ 
<
ŸŸ 
ActionResult
ŸŸ &
<
ŸŸ& '
ResponseDTO
ŸŸ' 2
>
ŸŸ2 3
>
ŸŸ3 4(
GetSectionsDetailsVersions
ŸŸ5 O
(
⁄⁄ 	
[
€€ 
	FromQuery
€€ 
]
€€ 
Guid
€€ 
?
€€ 
courseSectionId
€€ -
,
€€- .
[
‹‹ 
	FromQuery
‹‹ 
]
‹‹ 
string
‹‹ 
?
‹‹ 
filterOn
‹‹  (
,
‹‹( )
[
›› 
	FromQuery
›› 
]
›› 
string
›› 
?
›› 
filterQuery
››  +
,
››+ ,
[
ﬁﬁ 
	FromQuery
ﬁﬁ 
]
ﬁﬁ 
string
ﬁﬁ 
?
ﬁﬁ 
sortBy
ﬁﬁ  &
,
ﬁﬁ& '
[
ﬂﬂ 
	FromQuery
ﬂﬂ 
]
ﬂﬂ 
bool
ﬂﬂ 
?
ﬂﬂ 
isAscending
ﬂﬂ )
,
ﬂﬂ) *
[
‡‡ 
	FromQuery
‡‡ 
]
‡‡ 
int
‡‡ 

pageNumber
‡‡ &
=
‡‡' (
$num
‡‡) *
,
‡‡* +
[
·· 
	FromQuery
·· 
]
·· 
int
·· 
pageSize
·· $
=
··% &
$num
··' (
)
‚‚ 	
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
‰‰A B(
GetSectionsDetailsVersions
‰‰B \
(
ÂÂ 
User
ÊÊ 
,
ÊÊ 
courseSectionId
ÁÁ 
,
ÁÁ  
filterOn
ËË 
,
ËË 
filterQuery
ÈÈ 
,
ÈÈ 
sortBy
ÍÍ 
,
ÍÍ 
isAscending
ÎÎ 
,
ÎÎ 

pageNumber
ÏÏ 
,
ÏÏ 
pageSize
ÌÌ 
)
ÓÓ 
;
ÓÓ 
return
ÔÔ 

StatusCode
ÔÔ 
(
ÔÔ 
responseDto
ÔÔ )
.
ÔÔ) *

StatusCode
ÔÔ* 4
,
ÔÔ4 5
responseDto
ÔÔ6 A
)
ÔÔA B
;
ÔÔB C
}
 	
[
ÚÚ 	
HttpGet
ÚÚ	 
]
ÚÚ 
[
ÛÛ 	
Route
ÛÛ	 
(
ÛÛ 
$str
ÛÛ 1
)
ÛÛ1 2
]
ÛÛ2 3
[
ÙÙ 	
	Authorize
ÙÙ	 
]
ÙÙ 
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
GetSectionsDetailsVersion
ıı5 N
(
ııN O
[
ııO P
	FromRoute
ııP Y
]
ııY Z
Guid
ıı[ _
	detailsId
ıı` i
)
ııi j
{
ˆˆ 	
var
˜˜ 
responseDto
˜˜ 
=
˜˜ 
await
˜˜ #+
_sectionDetailsVersionService
˜˜$ A
.
˜˜A B&
GetSectionDetailsVersion
˜˜B Z
(
˜˜Z [
User
˜˜[ _
,
˜˜_ `
	detailsId
˜˜a j
)
˜˜j k
;
˜˜k l
return
¯¯ 

StatusCode
¯¯ 
(
¯¯ 
responseDto
¯¯ )
.
¯¯) *

StatusCode
¯¯* 4
,
¯¯4 5
responseDto
¯¯6 A
)
¯¯A B
;
¯¯B C
}
˘˘ 	
[
˚˚ 	
HttpPost
˚˚	 
]
˚˚ 
[
¸¸ 	
Route
¸¸	 
(
¸¸ 
$str
¸¸  
)
¸¸  !
]
¸¸! "
[
˝˝ 	
	Authorize
˝˝	 
(
˝˝ 
Roles
˝˝ 
=
˝˝ 
StaticUserRoles
˝˝ *
.
˝˝* +

Instructor
˝˝+ 5
)
˝˝5 6
]
˝˝6 7
public
˛˛ 
async
˛˛ 
Task
˛˛ 
<
˛˛ 
ActionResult
˛˛ &
<
˛˛& '
ResponseDTO
˛˛' 2
>
˛˛2 3
>
˛˛3 4)
CreateSectionDetailsVersion
˛˛5 P
(
˛˛P Q
[
ˇˇ 
FromBody
ˇˇ 
]
ˇˇ ,
CreateSectionDetailsVersionDTO
ˇˇ 5,
createSectionDetailsVersionDto
ˇˇ6 T
)
ˇˇT U
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
CreateSectionDetailsVersion
ÇÇ4 O
(
ÇÇO P
User
ÇÇP T
,
ÇÇT U,
createSectionDetailsVersionDto
ÇÇV t
)
ÇÇt u
;
ÇÇu v
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
ÜÜ 	
HttpPut
ÜÜ	 
]
ÜÜ 
[
áá 	
Route
áá	 
(
áá 
$str
áá  
)
áá  !
]
áá! "
[
àà 	
	Authorize
àà	 
(
àà 
Roles
àà 
=
àà 
StaticUserRoles
àà *
.
àà* +

Instructor
àà+ 5
)
àà5 6
]
àà6 7
public
ââ 
async
ââ 
Task
ââ 
<
ââ 
ActionResult
ââ &
<
ââ& '
ResponseDTO
ââ' 2
>
ââ2 3
>
ââ3 4'
EditSectionDetailsVersion
ââ5 N
(
ââN O
[
ää 
FromBody
ää 
]
ää *
EditSectionDetailsVersionDTO
ää 3*
editSectionDetailsVersionDto
ää4 P
)
ääP Q
{
ãã 	
var
åå 
responseDto
åå 
=
åå 
await
çç +
_sectionDetailsVersionService
çç 3
.
çç3 4'
EditSectionDetailsVersion
çç4 M
(
ççM N
User
ççN R
,
ççR S*
editSectionDetailsVersionDto
ççT p
)
ççp q
;
ççq r
return
éé 

StatusCode
éé 
(
éé 
responseDto
éé )
.
éé) *

StatusCode
éé* 4
,
éé4 5
responseDto
éé6 A
)
ééA B
;
ééB C
}
èè 	
[
ëë 	

HttpDelete
ëë	 
]
ëë 
[
íí 	
Route
íí	 
(
íí 
$str
íí 1
)
íí1 2
]
íí2 3
[
ìì 	
	Authorize
ìì	 
(
ìì 
Roles
ìì 
=
ìì 
StaticUserRoles
ìì *
.
ìì* +

Instructor
ìì+ 5
)
ìì5 6
]
ìì6 7
public
îî 
async
îî 
Task
îî 
<
îî 
ActionResult
îî &
<
îî& '
ResponseDTO
îî' 2
>
îî2 3
>
îî3 4)
RemoveSectionDetailsVersion
îî5 P
(
îîP Q
[
îîQ R
	FromRoute
îîR [
]
îî[ \
Guid
îî] a
	detailsId
îîb k
)
îîk l
{
ïï 	
var
ññ 
responseDto
ññ 
=
ññ 
await
óó +
_sectionDetailsVersionService
óó 3
.
óó3 4)
RemoveSectionDetailsVersion
óó4 O
(
óóO P
User
óóP T
,
óóT U
	detailsId
óóV _
)
óó_ `
;
óó` a
return
òò 

StatusCode
òò 
(
òò 
responseDto
òò )
.
òò) *

StatusCode
òò* 4
,
òò4 5
responseDto
òò6 A
)
òòA B
;
òòB C
}
ôô 	
[
õõ 	
HttpPost
õõ	 
]
õõ 
[
úú 	
Route
úú	 
(
úú 
$str
úú 9
)
úú9 :
]
úú: ;
[
ùù 	
	Authorize
ùù	 
(
ùù 
Roles
ùù 
=
ùù 
StaticUserRoles
ùù *
.
ùù* +

Instructor
ùù+ 5
)
ùù5 6
]
ùù6 7
public
ûû 
async
ûû 
Task
ûû 
<
ûû 
ActionResult
ûû &
<
ûû& '
ResponseDTO
ûû' 2
>
ûû2 3
>
ûû3 40
"UploadSectionDetailsVersionContent
ûû5 W
(
üü 	
[
†† 
	FromRoute
†† 
]
†† 
Guid
†† 
	detailsId
†† &
,
††& '3
%UploadSectionDetailsVersionContentDTO
°° 13
%uploadSectionDetailsVersionContentDto
°°2 W
)
¢¢ 	
{
££ 	
var
§§ 
responseDto
§§ 
=
§§ 
await
•• +
_sectionDetailsVersionService
•• 3
.
••3 40
"UploadSectionDetailsVersionContent
••4 V
(
¶¶ 
User
ßß 
,
ßß 
	detailsId
®® 
,
®® 3
%uploadSectionDetailsVersionContentDto
©© 9
)
™™ 
;
™™ 
return
´´ 

StatusCode
´´ 
(
´´ 
responseDto
´´ )
.
´´) *

StatusCode
´´* 4
,
´´4 5
responseDto
´´6 A
)
´´A B
;
´´B C
}
¨¨ 	
[
ÆÆ 	
HttpGet
ÆÆ	 
]
ÆÆ 
[
ØØ 	
Route
ØØ	 
(
ØØ 
$str
ØØ )
)
ØØ) *
]
ØØ* +
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
IActionResult
∞∞ '
>
∞∞' (1
#DisplaySectionDetailsVersionContent
∞∞) L
(
±± 	
[
≤≤ 
	FromQuery
≤≤ 
]
≤≤ 
Guid
≤≤ %
sectionDetailsVersionId
≤≤ 4
,
≤≤4 5
[
≥≥ 
	FromQuery
≥≥ 
]
≥≥ 
string
≥≥ 
userId
≥≥ %
,
≥≥% &
[
¥¥ 
	FromQuery
¥¥ 
]
¥¥ 
string
¥¥ 
type
¥¥ #
)
µµ 	
{
∂∂ 	
var
∑∑  
contentResponseDto
∑∑ "
=
∑∑# $
await
∏∏ +
_sectionDetailsVersionService
∏∏ 3
.
∏∏3 41
#DisplaySectionDetailsVersionContent
∏∏4 W
(
ππ %
sectionDetailsVersionId
∫∫ +
,
∫∫+ ,
userId
ªª 
,
ªª 
type
ºº 
)
ΩΩ 
;
ΩΩ 
if
øø 
(
øø  
contentResponseDto
øø "
.
øø" #
Stream
øø# )
is
øø* ,
null
øø- 1
)
øø1 2
{
¿¿ 
return
¡¡ 
NotFound
¡¡ 
(
¡¡  
$str
¡¡  7
)
¡¡7 8
;
¡¡8 9
}
¬¬ 
if
ƒƒ 
(
ƒƒ  
contentResponseDto
ƒƒ "
.
ƒƒ" #
ContentType
ƒƒ# .
is
ƒƒ/ 1"
StaticFileExtensions
ƒƒ2 F
.
ƒƒF G
Mov
ƒƒG J
or
ƒƒK M"
StaticFileExtensions
ƒƒN b
.
ƒƒb c
Mp4
ƒƒc f
)
ƒƒf g
{
≈≈ 
return
∆∆ 
File
∆∆ 
(
∆∆  
contentResponseDto
∆∆ .
.
∆∆. /
Stream
∆∆/ 5
,
∆∆5 6 
contentResponseDto
∆∆7 I
.
∆∆I J
ContentType
∆∆J U
)
∆∆U V
;
∆∆V W
}
«« 
return
…… 
File
…… 
(
……  
contentResponseDto
…… *
.
……* +
Stream
……+ 1
,
……1 2 
contentResponseDto
……3 E
.
……E F
ContentType
……F Q
,
……Q R 
contentResponseDto
……S e
.
……e f
FileName
……f n
)
……n o
;
……o p
}
   	
}
ÕÕ 
}ŒŒ Ë˘
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
;B C
private 
readonly "
ICourseProgressService /"
_courseProgressService0 F
;F G
public 
CourseController 
( 	
ICourseService 
courseService (
,( ) 
ICourseReviewService  
courseReviewService! 4
,4 5 
ICourseReportService  
courseReportService! 4
,4 5"
ICourseProgressService6 L!
courseProgressServiceM b
)b c
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
;6 7"
_courseProgressService "
=# $!
courseProgressService% :
;: ;
} 	
["" 	
HttpGet""	 
]"" 
public## 
async## 
Task## 
<## 
ActionResult## &
<##& '
ResponseDTO##' 2
>##2 3
>##3 4

GetCourses##5 ?
($$ 	
[%% 
	FromQuery%% 
]%% 
Guid%% 
?%% 
instructorId%% *
,%%* +
[&& 
	FromQuery&& 
]&& 
string&& 
?&& 
filterOn&&  (
,&&( )
['' 
	FromQuery'' 
]'' 
string'' 
?'' 
filterQuery''  +
,''+ ,
[(( 
	FromQuery(( 
](( 
string(( 
?(( 
sortBy((  &
,((& '
[)) 
	FromQuery)) 
])) 
bool)) 
?)) 
isAscending)) )
,))) *
[** 
	FromQuery** 
]** 
double** 
?** 
	fromPrice**  )
,**) *
[++ 
	FromQuery++ 
]++ 
double++ 
?++ 
toPrice++  '
,++' (
[,, 
	FromQuery,, 
],, 
int,, 

pageNumber,, &
=,,' (
$num,,) *
,,,* +
[-- 
	FromQuery-- 
]-- 
int-- 
pageSize-- $
=--% &
$num--' (
).. 	
{// 	
var00 
responseDto00 
=00 
await00 #
_courseService00$ 2
.002 3

GetCourses003 =
(11 
User22 
,22 
instructorId33 
,33 
filterOn44 
,44 
filterQuery55 
,55 
	fromPrice66 
,66 
toPrice77 
,77 
sortBy88 
,88 
isAscending99 
,99 

pageNumber:: 
,:: 
pageSize;; 
)<< 
;<< 
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
$strAA  
)AA  !
]AA! "
publicBB 
asyncBB 
TaskBB 
<BB 
ActionResultBB &
<BB& '
ResponseDTOBB' 2
>BB2 3
>BB3 4
	GetCourseBB5 >
(BB> ?
[BB? @
	FromRouteBB@ I
]BBI J
GuidBBK O
courseIdBBP X
)BBX Y
{CC 	
varDD 
responseDtoDD 
=DD 
awaitDD #
_courseServiceDD$ 2
.DD2 3
	GetCourseDD3 <
(DD< =
UserDD= A
,DDA B
courseIdDDC K
)DDK L
;DDL M
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
[HH 	
HttpPostHH	 
]HH 
[II 	
RouteII	 
(II 
$strII )
)II) *
]II* +
[JJ 	
	AuthorizeJJ	 
(JJ 
RolesJJ 
=JJ 
StaticUserRolesJJ *
.JJ* +
AdminInstructorJJ+ :
)JJ: ;
]JJ; <
publicKK 
asyncKK 
TaskKK 
<KK 
ActionResultKK &
<KK& '
ResponseDTOKK' 2
>KK2 3
>KK3 4
ActivateCourseKK5 C
(KKC D
[KKD E
	FromRouteKKE N
]KKN O
GuidKKP T
courseIdKKU ]
)KK] ^
{LL 	
varMM 
responseDtoMM 
=MM 
awaitMM #
_courseServiceMM$ 2
.MM2 3
ActivateCourseMM3 A
(MMA B
UserMMB F
,MMF G
courseIdMMH P
)MMP Q
;MMQ R
returnNN 

StatusCodeNN 
(NN 
responseDtoNN )
.NN) *

StatusCodeNN* 4
,NN4 5
responseDtoNN6 A
)NNA B
;NNB C
}OO 	
[QQ 	
HttpPostQQ	 
]QQ 
[RR 	
RouteRR	 
(RR 
$strRR +
)RR+ ,
]RR, -
[SS 	
	AuthorizeSS	 
(SS 
RolesSS 
=SS 
StaticUserRolesSS *
.SS* +
AdminInstructorSS+ :
)SS: ;
]SS; <
publicTT 
asyncTT 
TaskTT 
<TT 
ActionResultTT &
<TT& '
ResponseDTOTT' 2
>TT2 3
>TT3 4
DeactivateCourseTT5 E
(TTE F
[TTF G
	FromRouteTTG P
]TTP Q
GuidTTR V
courseIdTTW _
)TT_ `
{UU 	
varVV 
responseDtoVV 
=VV 
awaitVV #
_courseServiceVV$ 2
.VV2 3
DeactivateCourseVV3 C
(VVC D
UserVVD H
,VVH I
courseIdVVJ R
)VVR S
;VVS T
returnWW 

StatusCodeWW 
(WW 
responseDtoWW )
.WW) *

StatusCodeWW* 4
,WW4 5
responseDtoWW6 A
)WWA B
;WWB C
}XX 	
[[[ 	
HttpGet[[	 
][[ 
[\\ 	
Route\\	 
(\\ 
$str\\ 
)\\ 
]\\ 
[]] 	
	Authorize]]	 
]]] 
public^^ 
async^^ 
Task^^ 
<^^ 
ActionResult^^ &
<^^& '
ResponseDTO^^' 2
>^^2 3
>^^3 4
GetCourseReviews^^5 E
(__ 	
[`` 
	FromQuery`` 
]`` 
Guid`` 
?`` 
courseId`` &
,``& '
[aa 
	FromQueryaa 
]aa 
stringaa 
?aa 
filterOnaa  (
,aa( )
[bb 
	FromQuerybb 
]bb 
stringbb 
?bb 
filterQuerybb  +
,bb+ ,
[cc 
	FromQuerycc 
]cc 
stringcc 
?cc 
sortBycc  &
,cc& '
[dd 
	FromQuerydd 
]dd 
booldd 
?dd 
isAscendingdd )
,dd) *
[ee 
	FromQueryee 
]ee 
intee 

pageNumberee &
=ee' (
$numee) *
,ee* +
[ff 
	FromQueryff 
]ff 
intff 
pageSizeff $
=ff% &
$numff' (
)gg 	
{hh 	
varii 
responseDtoii 
=ii 
awaitii # 
_courseReviewServiceii$ 8
.ii8 9
GetCourseReviewsii9 I
(iiI J
Userjj 
,jj 
courseIdkk 
,kk 
filterOnll 
,ll 
filterQuerymm 
,mm 
sortBynn 
,nn 
isAscendingoo 
,oo 

pageNumberpp 
,pp 
pageSizeqq 
)rr 
;rr 
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
[ww 	
HttpGetww	 
]ww 
[xx 	
Routexx	 
(xx 
$strxx '
)xx' (
]xx( )
[yy 	
	Authorizeyy	 
]yy 
publiczz 
asynczz 
Taskzz 
<zz 
ActionResultzz &
<zz& '
ResponseDTOzz' 2
>zz2 3
>zz3 4
GetCourseReviewzz5 D
(zzD E
[zzE F
	FromRoutezzF O
]zzO P
GuidzzQ U
reviewIdzzV ^
)zz^ _
{{{ 	
try|| 
{}} 
var~~ 
responseDto~~ 
=~~  !
await~~" ' 
_courseReviewService~~( <
.~~< =
GetCourseReviewById~~= P
(~~P Q
reviewId~~Q Y
)~~Y Z
;~~Z [
return 

StatusCode !
(! "
responseDto" -
.- .

StatusCode. 8
,8 9
responseDto: E
)E F
;F G
}
ÄÄ 
catch
ÅÅ 
(
ÅÅ 
	Exception
ÅÅ 
ex
ÅÅ 
)
ÅÅ  
{
ÇÇ 
return
ÉÉ 

StatusCode
ÉÉ !
(
ÉÉ! "
$num
ÉÉ" %
,
ÉÉ% &
new
ÉÉ' *
ResponseDTO
ÉÉ+ 6
{
ÑÑ 
Message
ÖÖ 
=
ÖÖ 
ex
ÖÖ  
.
ÖÖ  !
Message
ÖÖ! (
,
ÖÖ( )
Result
ÜÜ 
=
ÜÜ 
null
ÜÜ !
,
ÜÜ! "
	IsSuccess
áá 
=
áá 
false
áá  %
,
áá% &

StatusCode
àà 
=
àà  
$num
àà! $
}
ââ 
)
ââ 
;
ââ 
}
ää 
}
ãã 	
[
çç 	
HttpPost
çç	 
]
çç 
[
éé 	
Route
éé	 
(
éé 
$str
éé 
)
éé 
]
éé 
[
èè 	
	Authorize
èè	 
(
èè 
Roles
èè 
=
èè 
StaticUserRoles
èè *
.
èè* +
Student
èè+ 2
)
èè2 3
]
èè3 4
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
êê3 4 
CreateCourseReview
êê5 G
(
êêG H
[
ëë 
FromBody
ëë 
]
ëë #
CreateCourseReviewDTO
ëë ,#
createCourseReviewDto
ëë- B
)
ëëB C
{
íí 	
if
ìì 
(
ìì 
!
ìì 

ModelState
ìì 
.
ìì 
IsValid
ìì #
)
ìì# $
{
îî 
return
ïï 

BadRequest
ïï !
(
ïï! "
new
ïï" %
ResponseDTO
ïï& 1
{
ññ 
Message
óó 
=
óó 
$str
óó ,
,
óó, -
Result
òò 
=
òò 

ModelState
òò '
,
òò' (
	IsSuccess
ôô 
=
ôô 
false
ôô  %
,
ôô% &

StatusCode
öö 
=
öö  
$num
öö! $
}
õõ 
)
õõ 
;
õõ 
}
úú 
try
ûû 
{
üü 
var
†† 
responseDto
†† 
=
††  !
await
††" '"
_courseReviewService
††( <
.
††< = 
CreateCourseReview
††= O
(
††O P#
createCourseReviewDto
††P e
)
††e f
;
††f g
return
°° 

StatusCode
°° !
(
°°! "
responseDto
°°" -
.
°°- .

StatusCode
°°. 8
,
°°8 9
responseDto
°°: E
)
°°E F
;
°°F G
}
¢¢ 
catch
££ 
(
££ 
	Exception
££ 
ex
££ 
)
££  
{
§§ 
return
•• 

StatusCode
•• !
(
••! "
$num
••" %
,
••% &
new
••' *
ResponseDTO
••+ 6
{
¶¶ 
Message
ßß 
=
ßß 
ex
ßß  
.
ßß  !
Message
ßß! (
,
ßß( )
Result
®® 
=
®® 
null
®® !
,
®®! "
	IsSuccess
©© 
=
©© 
false
©©  %
,
©©% &

StatusCode
™™ 
=
™™  
$num
™™! $
}
´´ 
)
´´ 
;
´´ 
}
¨¨ 
}
≠≠ 	
[
ØØ 	
HttpPut
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
∞∞ 
)
∞∞ 
]
∞∞ 
[
±± 	
	Authorize
±±	 
(
±± 
Roles
±± 
=
±± 
StaticUserRoles
±± *
.
±±* +
Student
±±+ 2
)
±±2 3
]
±±3 4
public
≤≤ 
async
≤≤ 
Task
≤≤ 
<
≤≤ 
ActionResult
≤≤ &
<
≤≤& '
ResponseDTO
≤≤' 2
>
≤≤2 3
>
≤≤3 4 
UpdateCourseReview
≤≤5 G
(
≤≤G H
[
≥≥ 
FromBody
≥≥ 
]
≥≥ #
UpdateCourseReviewDTO
≥≥ ,#
updateCourseReviewDto
≥≥- B
)
≥≥B C
{
¥¥ 	
if
µµ 
(
µµ 
!
µµ 

ModelState
µµ 
.
µµ 
IsValid
µµ #
)
µµ# $
{
∂∂ 
return
∑∑ 

BadRequest
∑∑ !
(
∑∑! "
new
∑∑" %
ResponseDTO
∑∑& 1
{
∏∏ 
Message
ππ 
=
ππ 
$str
ππ ,
,
ππ, -
Result
∫∫ 
=
∫∫ 

ModelState
∫∫ '
,
∫∫' (
	IsSuccess
ªª 
=
ªª 
false
ªª  %
,
ªª% &

StatusCode
ºº 
=
ºº  
$num
ºº! $
}
ΩΩ 
)
ΩΩ 
;
ΩΩ 
}
ææ 
try
¿¿ 
{
¡¡ 
var
¬¬ 
responseDto
¬¬ 
=
¬¬  !
await
¬¬" '"
_courseReviewService
¬¬( <
.
¬¬< = 
UpdateCourseReview
¬¬= O
(
¬¬O P
User
¬¬P T
,
¬¬T U#
updateCourseReviewDto
¬¬V k
)
¬¬k l
;
¬¬l m
return
√√ 

StatusCode
√√ !
(
√√! "
responseDto
√√" -
.
√√- .

StatusCode
√√. 8
,
√√8 9
responseDto
√√: E
)
√√E F
;
√√F G
}
ƒƒ 
catch
≈≈ 
(
≈≈ 
	Exception
≈≈ 
ex
≈≈ 
)
≈≈  
{
∆∆ 
return
«« 

StatusCode
«« !
(
««! "
$num
««" %
,
««% &
new
««' *
ResponseDTO
««+ 6
{
»» 
Message
…… 
=
…… 
ex
……  
.
……  !
Message
……! (
,
……( )
Result
   
=
   
null
   !
,
  ! "
	IsSuccess
ÀÀ 
=
ÀÀ 
false
ÀÀ  %
,
ÀÀ% &

StatusCode
ÃÃ 
=
ÃÃ  
$num
ÃÃ! $
}
ÕÕ 
)
ÕÕ 
;
ÕÕ 
}
ŒŒ 
}
œœ 	
[
—— 	

HttpDelete
——	 
]
—— 
[
““ 	
Route
““	 
(
““ 
$str
““ '
)
““' (
]
““( )
[
”” 	
	Authorize
””	 
]
”” 
public
‘‘ 
async
‘‘ 
Task
‘‘ 
<
‘‘ 
ActionResult
‘‘ &
<
‘‘& '
ResponseDTO
‘‘' 2
>
‘‘2 3
>
‘‘3 4 
DeleteCourseReview
‘‘5 G
(
‘‘G H
[
‘‘H I
	FromRoute
‘‘I R
]
‘‘R S
Guid
‘‘T X
reviewId
‘‘Y a
)
‘‘a b
{
’’ 	
try
÷÷ 
{
◊◊ 
var
ÿÿ 
responseDto
ÿÿ 
=
ÿÿ  !
await
ÿÿ" '"
_courseReviewService
ÿÿ( <
.
ÿÿ< = 
DeleteCourseReview
ÿÿ= O
(
ÿÿO P
reviewId
ÿÿP X
)
ÿÿX Y
;
ÿÿY Z
return
ŸŸ 

StatusCode
ŸŸ !
(
ŸŸ! "
responseDto
ŸŸ" -
.
ŸŸ- .

StatusCode
ŸŸ. 8
,
ŸŸ8 9
responseDto
ŸŸ: E
)
ŸŸE F
;
ŸŸF G
}
⁄⁄ 
catch
€€ 
(
€€ 
	Exception
€€ 
ex
€€ 
)
€€  
{
‹‹ 
return
›› 

StatusCode
›› !
(
››! "
$num
››" %
,
››% &
new
››' *
ResponseDTO
››+ 6
{
ﬁﬁ 
Message
ﬂﬂ 
=
ﬂﬂ 
ex
ﬂﬂ  
.
ﬂﬂ  !
Message
ﬂﬂ! (
,
ﬂﬂ( )
Result
‡‡ 
=
‡‡ 
null
‡‡ !
,
‡‡! "
	IsSuccess
·· 
=
·· 
false
··  %
,
··% &

StatusCode
‚‚ 
=
‚‚  
$num
‚‚! $
}
„„ 
)
„„ 
;
„„ 
}
‰‰ 
}
ÂÂ 	
[
ËË 	
HttpPut
ËË	 
]
ËË 
[
ÈÈ 	
Route
ÈÈ	 
(
ÈÈ 
$str
ÈÈ ,
)
ÈÈ, -
]
ÈÈ- .
[
ÍÍ 	
	Authorize
ÍÍ	 
(
ÍÍ 
Roles
ÍÍ 
=
ÍÍ 
StaticUserRoles
ÍÍ *
.
ÍÍ* +

Instructor
ÍÍ+ 5
)
ÍÍ5 6
]
ÍÍ6 7
public
ÎÎ 
async
ÎÎ 
Task
ÎÎ 
<
ÎÎ 
ActionResult
ÎÎ &
<
ÎÎ& '
ResponseDTO
ÎÎ' 2
>
ÎÎ2 3
>
ÎÎ3 4
MarkCourseReview
ÎÎ5 E
(
ÎÎE F
[
ÎÎF G
	FromRoute
ÎÎG P
]
ÎÎP Q
Guid
ÎÎR V
reviewId
ÎÎW _
)
ÎÎ_ `
{
ÏÏ 	
try
ÌÌ 
{
ÓÓ 
var
ÔÔ 
responseDto
ÔÔ 
=
ÔÔ  !
await
ÔÔ" '"
_courseReviewService
ÔÔ( <
.
ÔÔ< =
MarkCourseReview
ÔÔ= M
(
ÔÔM N
reviewId
ÔÔN V
)
ÔÔV W
;
ÔÔW X
return
 

StatusCode
 !
(
! "
responseDto
" -
.
- .

StatusCode
. 8
,
8 9
responseDto
: E
)
E F
;
F G
}
ÒÒ 
catch
ÚÚ 
(
ÚÚ 
	Exception
ÚÚ 
ex
ÚÚ 
)
ÚÚ  
{
ÛÛ 
return
ÙÙ 

StatusCode
ÙÙ !
(
ÙÙ! "
$num
ÙÙ" %
,
ÙÙ% &
new
ÙÙ' *
ResponseDTO
ÙÙ+ 6
{
ıı 
Message
ˆˆ 
=
ˆˆ 
ex
ˆˆ  
.
ˆˆ  !
Message
ˆˆ! (
,
ˆˆ( )
Result
˜˜ 
=
˜˜ 
null
˜˜ !
,
˜˜! "
	IsSuccess
¯¯ 
=
¯¯ 
false
¯¯  %
,
¯¯% &

StatusCode
˘˘ 
=
˘˘  
$num
˘˘! $
}
˙˙ 
)
˙˙ 
;
˙˙ 
}
˚˚ 
}
¸¸ 	
[
ˇˇ 	
HttpGet
ˇˇ	 
]
ˇˇ 
[
ÄÄ 	
Route
ÄÄ	 
(
ÄÄ 
$str
ÄÄ 
)
ÄÄ 
]
ÄÄ 
[
ÅÅ 	
	Authorize
ÅÅ	 
]
ÅÅ 
public
ÇÇ 
async
ÇÇ 
Task
ÇÇ 
<
ÇÇ 
ActionResult
ÇÇ &
<
ÇÇ& '
ResponseDTO
ÇÇ' 2
>
ÇÇ2 3
>
ÇÇ3 4
GetCourseReports
ÇÇ5 E
(
ÇÇE F
[
ÉÉ 
	FromQuery
ÉÉ 
]
ÉÉ 
Guid
ÉÉ 
?
ÉÉ 
courseId
ÉÉ &
,
ÉÉ& '
[
ÑÑ 
	FromQuery
ÑÑ 
]
ÑÑ 
string
ÑÑ 
?
ÑÑ 
filterOn
ÑÑ  (
,
ÑÑ( )
[
ÖÖ 
	FromQuery
ÖÖ 
]
ÖÖ 
string
ÖÖ 
?
ÖÖ 
filterQuery
ÖÖ  +
,
ÖÖ+ ,
[
ÜÜ 
	FromQuery
ÜÜ 
]
ÜÜ 
string
ÜÜ 
?
ÜÜ 
sortBy
ÜÜ  &
,
ÜÜ& '
[
áá 
	FromQuery
áá 
]
áá 
bool
áá 
?
áá 
isAscending
áá )
,
áá) *
[
àà 
	FromQuery
àà 
]
àà 
int
àà 

pageNumber
àà &
=
àà' (
$num
àà) *
,
àà* +
[
ââ 
	FromQuery
ââ 
]
ââ 
int
ââ 
pageSize
ââ $
=
ââ% &
$num
ââ' (
)
ää 	
{
ãã 	
var
åå 
responseDto
åå 
=
åå 
await
åå #"
_courseReportService
åå$ 8
.
åå8 9
GetCourseReports
åå9 I
(
ååI J
User
çç 
,
çç 
courseId
éé 
,
éé 
filterOn
èè 
,
èè 
filterQuery
êê 
,
êê 
sortBy
ëë 
,
ëë 
isAscending
íí 
,
íí 

pageNumber
ìì 
,
ìì 
pageSize
îî 
)
ïï 
;
ïï 
return
óó 

StatusCode
óó 
(
óó 
responseDto
óó )
.
óó) *

StatusCode
óó* 4
,
óó4 5
responseDto
óó6 A
)
óóA B
;
óóB C
}
òò 	
[
öö 	
HttpGet
öö	 
]
öö 
[
õõ 	
Route
õõ	 
(
õõ 
$str
õõ '
)
õõ' (
]
õõ( )
[
úú 	
	Authorize
úú	 
]
úú 
public
ùù 
async
ùù 
Task
ùù 
<
ùù 
ActionResult
ùù &
<
ùù& '
ResponseDTO
ùù' 2
>
ùù2 3
>
ùù3 4
GetCourseReport
ùù5 D
(
ùùD E
[
ùùE F
	FromRoute
ùùF O
]
ùùO P
Guid
ùùQ U
reportId
ùùV ^
)
ùù^ _
{
ûû 	
try
üü 
{
†† 
var
°° 
responseDto
°° 
=
°°  !
await
°°" '"
_courseReportService
°°( <
.
°°< =!
GetCourseReportById
°°= P
(
°°P Q
reportId
°°Q Y
)
°°Y Z
;
°°Z [
return
¢¢ 

StatusCode
¢¢ !
(
¢¢! "
responseDto
¢¢" -
.
¢¢- .

StatusCode
¢¢. 8
,
¢¢8 9
responseDto
¢¢: E
)
¢¢E F
;
¢¢F G
}
££ 
catch
§§ 
(
§§ 
	Exception
§§ 
ex
§§ 
)
§§  
{
•• 
return
¶¶ 

StatusCode
¶¶ !
(
¶¶! "
$num
¶¶" %
,
¶¶% &
new
¶¶' *
ResponseDTO
¶¶+ 6
{
ßß 
Message
®® 
=
®® 
ex
®®  
.
®®  !
Message
®®! (
,
®®( )
Result
©© 
=
©© 
null
©© !
,
©©! "
	IsSuccess
™™ 
=
™™ 
false
™™  %
,
™™% &

StatusCode
´´ 
=
´´  
$num
´´! $
}
¨¨ 
)
¨¨ 
;
¨¨ 
}
≠≠ 
}
ÆÆ 	
[
∞∞ 	
HttpPost
∞∞	 
]
∞∞ 
[
±± 	
Route
±±	 
(
±± 
$str
±± 
)
±± 
]
±± 
[
≤≤ 	
	Authorize
≤≤	 
(
≤≤ 
Roles
≤≤ 
=
≤≤ 
StaticUserRoles
≤≤ *
.
≤≤* +
Student
≤≤+ 2
)
≤≤2 3
]
≤≤3 4
public
≥≥ 
async
≥≥ 
Task
≥≥ 
<
≥≥ 
ActionResult
≥≥ &
<
≥≥& '
ResponseDTO
≥≥' 2
>
≥≥2 3
>
≥≥3 4 
CreateCourseReport
≥≥5 G
(
≥≥G H
[
¥¥ 
FromBody
¥¥ 
]
¥¥ #
CreateCourseReportDTO
¥¥ ,#
createCourseReportDTO
¥¥- B
)
¥¥B C
{
µµ 	
if
∂∂ 
(
∂∂ 
!
∂∂ 

ModelState
∂∂ 
.
∂∂ 
IsValid
∂∂ #
)
∂∂# $
{
∑∑ 
return
∏∏ 

BadRequest
∏∏ !
(
∏∏! "
new
∏∏" %
ResponseDTO
∏∏& 1
{
ππ 
Message
∫∫ 
=
∫∫ 
$str
∫∫ ,
,
∫∫, -
Result
ªª 
=
ªª 

ModelState
ªª '
,
ªª' (
	IsSuccess
ºº 
=
ºº 
false
ºº  %
,
ºº% &

StatusCode
ΩΩ 
=
ΩΩ  
$num
ΩΩ! $
}
ææ 
)
ææ 
;
ææ 
}
øø 
try
¡¡ 
{
¬¬ 
var
√√ 
responseDto
√√ 
=
√√  !
await
√√" '"
_courseReportService
√√( <
.
√√< = 
CreateCourseReport
√√= O
(
√√O P#
createCourseReportDTO
√√P e
)
√√e f
;
√√f g
return
ƒƒ 

StatusCode
ƒƒ !
(
ƒƒ! "
responseDto
ƒƒ" -
.
ƒƒ- .

StatusCode
ƒƒ. 8
,
ƒƒ8 9
responseDto
ƒƒ: E
)
ƒƒE F
;
ƒƒF G
}
≈≈ 
catch
∆∆ 
(
∆∆ 
	Exception
∆∆ 
ex
∆∆ 
)
∆∆  
{
«« 
return
»» 

StatusCode
»» !
(
»»! "
$num
»»" %
,
»»% &
new
»»' *
ResponseDTO
»»+ 6
{
…… 
Message
   
=
   
ex
    
.
    !
Message
  ! (
,
  ( )
Result
ÀÀ 
=
ÀÀ 
null
ÀÀ !
,
ÀÀ! "
	IsSuccess
ÃÃ 
=
ÃÃ 
false
ÃÃ  %
,
ÃÃ% &

StatusCode
ÕÕ 
=
ÕÕ  
$num
ÕÕ! $
}
ŒŒ 
)
ŒŒ 
;
ŒŒ 
}
œœ 
}
–– 	
[
““ 	
HttpPut
““	 
]
““ 
[
”” 	
Route
””	 
(
”” 
$str
”” 
)
”” 
]
”” 
[
‘‘ 	
	Authorize
‘‘	 
(
‘‘ 
Roles
‘‘ 
=
‘‘ 
StaticUserRoles
‘‘ *
.
‘‘* +
Student
‘‘+ 2
)
‘‘2 3
]
‘‘3 4
public
’’ 
async
’’ 
Task
’’ 
<
’’ 
ActionResult
’’ &
<
’’& '
ResponseDTO
’’' 2
>
’’2 3
>
’’3 4 
UpdateCourseReport
’’5 G
(
’’G H
[
÷÷ 
FromBody
÷÷ 
]
÷÷ #
UpdateCourseReportDTO
÷÷ ,#
updateCourseReportDTO
÷÷- B
)
÷÷B C
{
◊◊ 	
if
ÿÿ 
(
ÿÿ 
!
ÿÿ 

ModelState
ÿÿ 
.
ÿÿ 
IsValid
ÿÿ #
)
ÿÿ# $
{
ŸŸ 
return
⁄⁄ 

BadRequest
⁄⁄ !
(
⁄⁄! "
new
⁄⁄" %
ResponseDTO
⁄⁄& 1
{
€€ 
Message
‹‹ 
=
‹‹ 
$str
‹‹ ,
,
‹‹, -
Result
›› 
=
›› 

ModelState
›› '
,
››' (
	IsSuccess
ﬁﬁ 
=
ﬁﬁ 
false
ﬁﬁ  %
,
ﬁﬁ% &

StatusCode
ﬂﬂ 
=
ﬂﬂ  
$num
ﬂﬂ! $
}
‡‡ 
)
‡‡ 
;
‡‡ 
}
·· 
try
„„ 
{
‰‰ 
var
ÂÂ 
responseDto
ÂÂ 
=
ÂÂ  !
await
ÂÂ" '"
_courseReportService
ÂÂ( <
.
ÂÂ< = 
UpdateCourseReport
ÂÂ= O
(
ÂÂO P
User
ÂÂP T
,
ÂÂT U#
updateCourseReportDTO
ÂÂV k
)
ÂÂk l
;
ÂÂl m
return
ÊÊ 

StatusCode
ÊÊ !
(
ÊÊ! "
responseDto
ÊÊ" -
.
ÊÊ- .

StatusCode
ÊÊ. 8
,
ÊÊ8 9
responseDto
ÊÊ: E
)
ÊÊE F
;
ÊÊF G
}
ÁÁ 
catch
ËË 
(
ËË 
	Exception
ËË 
ex
ËË 
)
ËË  
{
ÈÈ 
return
ÍÍ 

StatusCode
ÍÍ !
(
ÍÍ! "
$num
ÍÍ" %
,
ÍÍ% &
new
ÍÍ' *
ResponseDTO
ÍÍ+ 6
{
ÎÎ 
Message
ÏÏ 
=
ÏÏ 
ex
ÏÏ  
.
ÏÏ  !
Message
ÏÏ! (
,
ÏÏ( )
Result
ÌÌ 
=
ÌÌ 
null
ÌÌ !
,
ÌÌ! "
	IsSuccess
ÓÓ 
=
ÓÓ 
false
ÓÓ  %
,
ÓÓ% &

StatusCode
ÔÔ 
=
ÔÔ  
$num
ÔÔ! $
}
 
)
 
;
 
}
ÒÒ 
}
ÚÚ 	
[
ÙÙ 	

HttpDelete
ÙÙ	 
]
ÙÙ 
[
ıı 	
Route
ıı	 
(
ıı 
$str
ıı '
)
ıı' (
]
ıı( )
[
ˆˆ 	
	Authorize
ˆˆ	 
(
ˆˆ 
Roles
ˆˆ 
=
ˆˆ 
StaticUserRoles
ˆˆ *
.
ˆˆ* +
AdminStudent
ˆˆ+ 7
)
ˆˆ7 8
]
ˆˆ8 9
public
˜˜ 
async
˜˜ 
Task
˜˜ 
<
˜˜ 
ActionResult
˜˜ &
<
˜˜& '
ResponseDTO
˜˜' 2
>
˜˜2 3
>
˜˜3 4 
DeleteCourseReport
˜˜5 G
(
˜˜G H
[
˜˜H I
	FromRoute
˜˜I R
]
˜˜R S
Guid
˜˜T X
reportId
˜˜Y a
)
˜˜a b
{
¯¯ 	
try
˘˘ 
{
˙˙ 
var
˚˚ 
responseDto
˚˚ 
=
˚˚  !
await
˚˚" '"
_courseReportService
˚˚( <
.
˚˚< = 
DeleteCourseReport
˚˚= O
(
˚˚O P
reportId
˚˚P X
)
˚˚X Y
;
˚˚Y Z
return
¸¸ 

StatusCode
¸¸ !
(
¸¸! "
responseDto
¸¸" -
.
¸¸- .

StatusCode
¸¸. 8
,
¸¸8 9
responseDto
¸¸: E
)
¸¸E F
;
¸¸F G
}
˝˝ 
catch
˛˛ 
(
˛˛ 
	Exception
˛˛ 
ex
˛˛ 
)
˛˛  
{
ˇˇ 
return
ÄÄ 

StatusCode
ÄÄ !
(
ÄÄ! "
$num
ÄÄ" %
,
ÄÄ% &
new
ÄÄ' *
ResponseDTO
ÄÄ+ 6
{
ÅÅ 
Message
ÇÇ 
=
ÇÇ 
ex
ÇÇ  
.
ÇÇ  !
Message
ÇÇ! (
,
ÇÇ( )
Result
ÉÉ 
=
ÉÉ 
null
ÉÉ !
,
ÉÉ! "
	IsSuccess
ÑÑ 
=
ÑÑ 
false
ÑÑ  %
,
ÑÑ% &

StatusCode
ÖÖ 
=
ÖÖ  
$num
ÖÖ! $
}
ÜÜ 
)
ÜÜ 
;
ÜÜ 
}
áá 
}
àà 	
[
ää 	
HttpGet
ää	 
]
ää 
[
ãã 	
Route
ãã	 
(
ãã 
$str
ãã 
)
ãã 
]
ãã  
[
åå 	
	Authorize
åå	 
(
åå 
Roles
åå 
=
åå 
StaticUserRoles
åå *
.
åå* +
Admin
åå+ 0
)
åå0 1
]
åå1 2
public
çç 
async
çç 
Task
çç 
<
çç 
ActionResult
çç &
<
çç& '
ResponseDTO
çç' 2
>
çç2 3
>
çç3 4$
GetTopPurchasedCourses
çç5 K
(
éé 	
[
èè 
	FromQuery
èè 
]
èè 
int
èè 
?
èè 
year
èè !
,
èè! "
[
êê 
	FromQuery
êê 
]
êê 
int
êê 
?
êê 
month
êê "
,
êê" #
[
ëë 
	FromQuery
ëë 
]
ëë 
int
ëë 
?
ëë 
quarter
ëë $
,
ëë$ %
[
íí 
	FromQuery
íí 
]
íí 
int
íí 
top
íí 
,
íí  
[
ìì 
	FromQuery
ìì 
]
ìì 
int
ìì 

pageNumber
ìì &
,
ìì& '
[
îî 
	FromQuery
îî 
]
îî 
int
îî 
pageSize
îî $
,
îî$ %
[
ïï 
	FromQuery
ïï 
]
ïï 
string
ïï 
?
ïï 
byCategoryName
ïï  .
)
ññ 	
{
óó 	
var
òò 
responseDto
òò 
=
òò 
await
òò #
_courseService
òò$ 2
.
òò2 3$
GetTopPurchasedCourses
òò3 I
(
ôô 
year
öö 
,
öö 
month
õõ 
,
õõ 
quarter
úú 
,
úú 
top
ùù 
,
ùù 

pageNumber
ûû 
,
ûû 
pageSize
üü 
,
üü 
byCategoryName
†† 
)
°° 
;
°° 
return
¢¢ 

StatusCode
¢¢ 
(
¢¢ 
responseDto
¢¢ )
.
¢¢) *

StatusCode
¢¢* 4
,
¢¢4 5
responseDto
¢¢6 A
)
¢¢A B
;
¢¢B C
}
££ 	
[
•• 	
HttpGet
••	 
]
•• 
[
¶¶ 	
Route
¶¶	 
(
¶¶ 
$str
¶¶  
)
¶¶  !
]
¶¶! "
[
ßß 	
	Authorize
ßß	 
(
ßß 
Roles
ßß 
=
ßß 
StaticUserRoles
ßß *
.
ßß* +
Admin
ßß+ 0
)
ßß0 1
]
ßß1 2
public
®® 
async
®® 
Task
®® 
<
®® 
ActionResult
®® &
<
®®& '
ResponseDTO
®®' 2
>
®®2 3
>
®®3 4&
GetLeastPurchasedCourses
®®5 M
(
©© 	
[
™™ 
	FromQuery
™™ 
]
™™ 
int
™™ 
?
™™ 
year
™™ !
,
™™! "
[
´´ 
	FromQuery
´´ 
]
´´ 
int
´´ 
?
´´ 
month
´´ "
,
´´" #
[
¨¨ 
	FromQuery
¨¨ 
]
¨¨ 
int
¨¨ 
?
¨¨ 
quarter
¨¨ $
,
¨¨$ %
[
≠≠ 
	FromQuery
≠≠ 
]
≠≠ 
int
≠≠ 
top
≠≠ 
,
≠≠  
[
ÆÆ 
	FromQuery
ÆÆ 
]
ÆÆ 
int
ÆÆ 

pageNumber
ÆÆ &
,
ÆÆ& '
[
ØØ 
	FromQuery
ØØ 
]
ØØ 
int
ØØ 
pageSize
ØØ $
,
ØØ$ %
[
∞∞ 
	FromQuery
∞∞ 
]
∞∞ 
string
∞∞ 
?
∞∞ 
byCategoryName
∞∞  .
)
±± 	
{
≤≤ 	
var
≥≥ 
responseDto
≥≥ 
=
≥≥ 
await
≥≥ #
_courseService
≥≥$ 2
.
≥≥2 3&
GetLeastPurchasedCourses
≥≥3 K
(
¥¥ 
year
µµ 
,
µµ 
month
∂∂ 
,
∂∂ 
quarter
∑∑ 
,
∑∑ 
top
∏∏ 
,
∏∏ 

pageNumber
ππ 
,
ππ 
pageSize
∫∫ 
,
∫∫ 
byCategoryName
ªª 
)
ºº 
;
ºº 
return
ΩΩ 

StatusCode
ΩΩ 
(
ΩΩ 
responseDto
ΩΩ )
.
ΩΩ) *

StatusCode
ΩΩ* 4
,
ΩΩ4 5
responseDto
ΩΩ6 A
)
ΩΩA B
;
ΩΩB C
}
ææ 	
[
¿¿ 	
HttpPost
¿¿	 
]
¿¿ 
[
¡¡ 	
Route
¡¡	 
(
¡¡ 
$str
¡¡ 
)
¡¡ 
]
¡¡ 
[
¬¬ 	
	Authorize
¬¬	 
(
¬¬ 
Roles
¬¬ 
=
¬¬ 
StaticUserRoles
¬¬ *
.
¬¬* +
Student
¬¬+ 2
)
¬¬2 3
]
¬¬3 4
public
√√ 
async
√√ 
Task
√√ 
<
√√ 
ActionResult
√√ &
<
√√& '
ResponseDTO
√√' 2
>
√√2 3
>
√√3 4
EnrollCourse
√√5 A
(
√√A B
[
√√B C
FromBody
√√C K
]
√√K L
EnrollCourseDTO
√√M \
enrollCourseDto
√√] l
)
√√l m
{
ƒƒ 	
var
≈≈ 
responseDto
≈≈ 
=
≈≈ 
await
≈≈ #
_courseService
≈≈$ 2
.
≈≈2 3
EnrollCourse
≈≈3 ?
(
≈≈? @
User
≈≈@ D
,
≈≈D E
enrollCourseDto
≈≈F U
)
≈≈U V
;
≈≈V W
return
∆∆ 

StatusCode
∆∆ 
(
∆∆ 
responseDto
∆∆ )
.
∆∆) *

StatusCode
∆∆* 4
,
∆∆4 5
responseDto
∆∆6 A
)
∆∆A B
;
∆∆B C
}
«« 	
[
…… 	
HttpGet
……	 
]
…… 
[
   	
Route
  	 
(
   
$str
   )
)
  ) *
]
  * +
[
ÀÀ 	
	Authorize
ÀÀ	 
(
ÀÀ 
Roles
ÀÀ 
=
ÀÀ 
StaticUserRoles
ÀÀ *
.
ÀÀ* +
Student
ÀÀ+ 2
)
ÀÀ2 3
]
ÀÀ3 4
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
<
ÃÃ 
ActionResult
ÃÃ &
>
ÃÃ& '
SuggestCourses
ÃÃ( 6
(
ÃÃ6 7
[
ÃÃ7 8
	FromRoute
ÃÃ8 A
]
ÃÃA B
Guid
ÃÃC G
	studentId
ÃÃH Q
)
ÃÃQ R
{
ÕÕ 	
var
ŒŒ 
response
ŒŒ 
=
ŒŒ 
await
ŒŒ  
_courseService
ŒŒ! /
.
ŒŒ/ 0
SuggestCourse
ŒŒ0 =
(
ŒŒ= >
	studentId
ŒŒ> G
)
ŒŒG H
;
ŒŒH I
return
œœ 

StatusCode
œœ 
(
œœ 
response
œœ &
.
œœ& '

StatusCode
œœ' 1
,
œœ1 2
response
œœ3 ;
)
œœ; <
;
œœ< =
}
–– 	
[
““ 	
HttpGet
““	 
(
““ 
$str
““ .
)
““. /
]
““/ 0
[
”” 	
	Authorize
””	 
(
”” 
Roles
”” 
=
”” 
StaticUserRoles
”” *
.
””* +
Student
””+ 2
)
””2 3
]
””3 4
public
‘‘ 
async
‘‘ 
Task
‘‘ 
<
‘‘ 
IActionResult
‘‘ '
>
‘‘' ()
GetAllBookMarkedCoursesById
‘‘) D
(
’’ 	
[
÷÷ 
	FromRoute
÷÷ 
]
÷÷ 
Guid
÷÷ 
	studentId
÷÷ &
,
÷÷& '
[
◊◊ 
	FromQuery
◊◊ 
]
◊◊ 
string
◊◊ 
	sortOrder
◊◊ (
=
◊◊) *
$str
◊◊+ 1
)
ÿÿ 	
{
ŸŸ 	
var
⁄⁄ 
response
⁄⁄ 
=
⁄⁄ 
await
⁄⁄  
_courseService
⁄⁄! /
.
⁄⁄/ 0)
GetAllBookMarkedCoursesById
⁄⁄0 K
(
⁄⁄K L
	studentId
⁄⁄L U
,
⁄⁄U V
	sortOrder
⁄⁄W `
)
⁄⁄` a
;
⁄⁄a b
return
€€ 

StatusCode
€€ 
(
€€ 
response
€€ &
.
€€& '

StatusCode
€€' 1
,
€€1 2
response
€€3 ;
)
€€; <
;
€€< =
}
‹‹ 	
[
ﬁﬁ 	
HttpPost
ﬁﬁ	 
]
ﬁﬁ 
[
ﬂﬂ 	
Route
ﬂﬂ	 
(
ﬂﬂ 
$str
ﬂﬂ 
)
ﬂﬂ 
]
ﬂﬂ 
[
‡‡ 	
	Authorize
‡‡	 
(
‡‡ 
Roles
‡‡ 
=
‡‡ 
StaticUserRoles
‡‡ *
.
‡‡* +
Student
‡‡+ 2
)
‡‡2 3
]
‡‡3 4
public
·· 
async
·· 
Task
·· 
<
·· 
ActionResult
·· &
>
··& '$
CreateBookMarkedCourse
··( >
(
··> ?%
CreateCourseBookmarkDTO
··? V%
createCourseBookmarkDto
··W n
)
··n o
{
‚‚ 	
var
„„ 
response
„„ 
=
„„ 
await
„„  
_courseService
„„! /
.
„„/ 0$
CreateBookMarkedCourse
„„0 F
(
„„F G
User
„„G K
,
„„K L%
createCourseBookmarkDto
„„M d
)
„„d e
;
„„e f
return
‰‰ 

StatusCode
‰‰ 
(
‰‰ 
response
‰‰ &
.
‰‰& '

StatusCode
‰‰' 1
,
‰‰1 2
response
‰‰3 ;
)
‰‰; <
;
‰‰< =
}
ÂÂ 	
[
ÁÁ 	

HttpDelete
ÁÁ	 
]
ÁÁ 
[
ËË 	
Route
ËË	 
(
ËË 
$str
ËË /
)
ËË/ 0
]
ËË0 1
[
ÈÈ 	
	Authorize
ÈÈ	 
(
ÈÈ 
Roles
ÈÈ 
=
ÈÈ 
StaticUserRoles
ÈÈ *
.
ÈÈ* +
Student
ÈÈ+ 2
)
ÈÈ2 3
]
ÈÈ3 4
public
ÍÍ 
async
ÍÍ 
Task
ÍÍ 
<
ÍÍ 
ActionResult
ÍÍ &
>
ÍÍ& '$
DeleteBookMarkedCourse
ÍÍ( >
(
ÍÍ> ?
[
ÍÍ? @
	FromRoute
ÍÍ@ I
]
ÍÍI J
Guid
ÍÍK O
bookmarkedId
ÍÍP \
)
ÍÍ\ ]
{
ÎÎ 	
var
ÏÏ 
response
ÏÏ 
=
ÏÏ 
await
ÏÏ  
_courseService
ÏÏ! /
.
ÏÏ/ 0$
DeleteBookMarkedCourse
ÏÏ0 F
(
ÏÏF G
bookmarkedId
ÏÏG S
)
ÏÏS T
;
ÏÏT U
return
ÌÌ 

StatusCode
ÌÌ 
(
ÌÌ 
response
ÌÌ &
.
ÌÌ& '

StatusCode
ÌÌ' 1
,
ÌÌ1 2
response
ÌÌ3 ;
)
ÌÌ; <
;
ÌÌ< =
}
ÓÓ 	
[
 	
HttpPut
	 
]
 
[
ÒÒ 	
Route
ÒÒ	 
(
ÒÒ 
$str
ÒÒ 
)
ÒÒ 
]
ÒÒ 
[
ÚÚ 	
	Authorize
ÚÚ	 
(
ÚÚ 
Roles
ÚÚ 
=
ÚÚ 
StaticUserRoles
ÚÚ *
.
ÚÚ* +
Student
ÚÚ+ 2
)
ÚÚ2 3
]
ÚÚ3 4
public
ÛÛ 
async
ÛÛ 
Task
ÛÛ 
<
ÛÛ 
ActionResult
ÛÛ &
<
ÛÛ& '
ResponseDTO
ÛÛ' 2
>
ÛÛ2 3
>
ÛÛ3 4"
UpdateCourseProgress
ÛÛ5 I
(
ÙÙ 	
[
ıı 
FromBody
ıı 
]
ıı 
UpdateProgressDTO
ıı (
updateProgressDto
ıı) :
)
ˆˆ 	
{
˜˜ 	
var
¯¯ 
responseDto
¯¯ 
=
¯¯ 
await
¯¯ #$
_courseProgressService
¯¯$ :
.
¯¯: ;
UpdateProgress
¯¯; I
(
¯¯I J
updateProgressDto
¯¯J [
)
¯¯[ \
;
¯¯\ ]
return
˘˘ 

StatusCode
˘˘ 
(
˘˘ 
responseDto
˘˘ )
.
˘˘) *

StatusCode
˘˘* 4
,
˘˘4 5
responseDto
˘˘6 A
)
˘˘A B
;
˘˘B C
}
˙˙ 	
[
¸¸ 	
HttpGet
¸¸	 
]
¸¸ 
[
˝˝ 	
Route
˝˝	 
(
˝˝ 
$str
˝˝ 
)
˝˝ 
]
˝˝ 
[
˛˛ 	
	Authorize
˛˛	 
(
˛˛ 
Roles
˛˛ 
=
˛˛ 
StaticUserRoles
˛˛ *
.
˛˛* +
Student
˛˛+ 2
)
˛˛2 3
]
˛˛3 4
public
ˇˇ 
async
ˇˇ 
Task
ˇˇ 
<
ˇˇ 
ActionResult
ˇˇ &
<
ˇˇ& '
ResponseDTO
ˇˇ' 2
>
ˇˇ2 3
>
ˇˇ3 4
GetCourseProgress
ˇˇ5 F
(
ÄÄ 	
[
ÅÅ 
	FromQuery
ÅÅ 
]
ÅÅ 
GetProgressDTO
ÅÅ &
getProgressDto
ÅÅ' 5
)
ÇÇ 	
{
ÉÉ 	
var
ÑÑ 
responseDto
ÑÑ 
=
ÑÑ 
await
ÑÑ #$
_courseProgressService
ÑÑ$ :
.
ÑÑ: ;
GetProgress
ÑÑ; F
(
ÑÑF G
getProgressDto
ÑÑG U
)
ÑÑU V
;
ÑÑV W
return
ÖÖ 

StatusCode
ÖÖ 
(
ÖÖ 
responseDto
ÖÖ )
.
ÖÖ) *

StatusCode
ÖÖ* 4
,
ÖÖ4 5
responseDto
ÖÖ6 A
)
ÖÖA B
;
ÖÖB C
}
ÜÜ 	
[
àà 	
HttpGet
àà	 
]
àà 
[
ââ 	
Route
ââ	 
(
ââ 
$str
ââ $
)
ââ$ %
]
ââ% &
[
ää 	
	Authorize
ää	 
(
ää 
Roles
ää 
=
ää 
StaticUserRoles
ää *
.
ää* +
Student
ää+ 2
)
ää2 3
]
ää3 4
public
ãã 
async
ãã 
Task
ãã 
<
ãã 
ActionResult
ãã &
<
ãã& '
ResponseDTO
ãã' 2
>
ãã2 3
>
ãã3 4#
GetProgressPercentage
ãã5 J
(
åå 	
[
çç 
	FromQuery
çç 
]
çç 
GetPercentageDTO
çç (
getPercentageDto
çç) 9
)
éé 	
{
èè 	
var
êê 
responseDto
êê 
=
êê 
await
êê #$
_courseProgressService
êê$ :
.
êê: ;
GetPercentage
êê; H
(
êêH I
getPercentageDto
êêI Y
)
êêY Z
;
êêZ [
return
ëë 

StatusCode
ëë 
(
ëë 
responseDto
ëë )
.
ëë) *

StatusCode
ëë* 4
,
ëë4 5
responseDto
ëë6 A
)
ëëA B
;
ëëB C
}
íí 	
[
îî 	
HttpGet
îî	 
]
îî 
[
ïï 	
Route
ïï	 
(
ïï 
$str
ïï %
)
ïï% &
]
ïï& '
public
ññ 
async
ññ 
Task
ññ 
<
ññ 
ActionResult
ññ &
<
ññ& '
ResponseDTO
ññ' 2
>
ññ2 3
>
ññ3 4&
GetBestCoursesSuggestion
ññ5 M
(
ññM N
)
ññN O
{
óó 	
var
òò 
responseDto
òò 
=
òò 
await
òò #
_courseService
òò$ 2
.
òò2 3&
GetBestCoursesSuggestion
òò3 K
(
òòK L
)
òòL M
;
òòM N
return
ôô 

StatusCode
ôô 
(
ôô 
responseDto
ôô )
.
ôô) *

StatusCode
ôô* 4
,
ôô4 5
responseDto
ôô6 A
)
ôôA B
;
ôôB C
}
öö 	
[
úú 	
HttpGet
úú	 
]
úú 
[
ùù 	
Route
ùù	 
(
ùù 
$str
ùù %
)
ùù% &
]
ùù& '
public
ûû 
async
ûû 
Task
ûû 
<
ûû 
ActionResult
ûû &
<
ûû& '
ResponseDTO
ûû' 2
>
ûû2 3
>
ûû3 4/
!GetTopCoursesByTrendingCategories
ûû5 V
(
ûûV W
)
ûûW X
{
üü 	
var
†† 
responseDto
†† 
=
†† 
await
†† #
_courseService
††$ 2
.
††2 3/
!GetTopCoursesByTrendingCategories
††3 T
(
††T U
)
††U V
;
††V W
return
°° 

StatusCode
°° 
(
°° 
responseDto
°° )
.
°°) *

StatusCode
°°* 4
,
°°4 5
responseDto
°°6 A
)
°°A B
;
°°B C
}
¢¢ 	
[
§§ 	
HttpGet
§§	 
]
§§ 
[
•• 	
Route
••	 
(
•• 
$str
•• !
)
••! "
]
••" #
public
¶¶ 
async
¶¶ 
Task
¶¶ 
<
¶¶ 
ActionResult
¶¶ &
<
¶¶& '
ResponseDTO
¶¶' 2
>
¶¶2 3
>
¶¶3 4 
GetTopRatedCourses
¶¶5 G
(
¶¶G H
)
¶¶H I
{
ßß 	
var
®® 
responseDto
®® 
=
®® 
await
®® #
_courseService
®®$ 2
.
®®2 3 
GetTopRatedCourses
®®3 E
(
®®E F
)
®®F G
;
®®G H
return
©© 

StatusCode
©© 
(
©© 
responseDto
©© )
.
©©) *

StatusCode
©©* 4
,
©©4 5
responseDto
©©6 A
)
©©A B
;
©©B C
}
™™ 	
}
´´ 
}¨¨ Â
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
.& '
Student' .
). /
]/ 0
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
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
async 
Task 
< 
ActionResult &
<& '
ResponseDTO' 2
>2 3
>3 4
	AddToCart5 >
(> ?
[? @
FromBody@ H
]H I
AddToCartDTOJ V
addToCartDtoW c
)c d
{ 	
var   
responseDto   
=   
await   #
_cartService  $ 0
.  0 1
	AddToCart  1 :
(!! 
User"" 
,"" 
addToCartDto## 
)$$ 
;$$ 
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
[(( 	

HttpDelete((	 
](( 
[)) 	
Route))	 
()) 
$str)) )
)))) *
]))* +
public** 
async** 
Task** 
<** 
ActionResult** &
<**& '
ResponseDTO**' 2
>**2 3
>**3 4
RemoveFromCart**5 C
(**C D
[**D E
	FromRoute**E N
]**N O
Guid**P T
cartDetailsId**U b
)**b c
{++ 	
var,, 
responseDto,, 
=,, 
await,, #
_cartService,,$ 0
.,,0 1
RemoveFromCart,,1 ?
(-- 
User.. 
,.. 
cartDetailsId// 
)00 
;00 
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
}33 
}44 ¬P
kD:\FPT\Semester 6\Project_Cursus\Backend_Cursus\Cursus.LMS\Cursus.LMS.API\Controllers\CategoryController.cs
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
CategoryController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
ICategoryService )
_categoryService* :
;: ;
public 
CategoryController !
(! "
ICategoryService" 2
categoryService3 B
)B C
{ 	
_categoryService 
= 
categoryService .
;. /
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
>3 4
GetAll5 ;
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
_categoryService   &
.  & '
GetAll  ' -
(  - .
User  . 2
,  2 3
filterOn  4 <
,  < =
filterQuery  > I
,  I J
sortBy  K Q
,  Q R
isAscending  S ^
,  ^ _

pageNumber  ` j
,  j k
pageSize  l t
)  t u
;  u v
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
$str%% 
)%% 
]%% 
public&& 
async&& 
Task&& 
<&& 
ActionResult&& &
<&&& '
ResponseDTO&&' 2
>&&2 3
>&&3 4
Search&&5 ;
('' 	
[(( 
	FromQuery(( 
](( 
string(( 
?(( 
filterOn((  (
,((( )
[)) 
	FromQuery)) 
])) 
string)) 
?)) 
filterQuery))  +
,))+ ,
[** 
	FromQuery** 
]** 
string** 
?** 
sortBy**  &
,**& '
[++ 
	FromQuery++ 
]++ 
bool++ 
?++ 
isAscending++ )
,++) *
[,, 
	FromQuery,, 
],, 
int,, 

pageNumber,, &
=,,' (
$num,,) *
,,,* +
[-- 
	FromQuery-- 
]-- 
int-- 
pageSize-- $
=--% &
$num--' (
).. 	
{// 	
var00 
responseDto00 
=00 
await00 #
_categoryService00$ 4
.004 5
Search005 ;
(00; <
User00< @
,00@ A
filterOn00B J
,00J K
filterQuery00L W
,00W X
sortBy00Y _
,00_ `
isAscending00a l
,00l m

pageNumber11 
,11 
pageSize11 $
)11$ %
;11% &
return22 

StatusCode22 
(22 
responseDto22 )
.22) *

StatusCode22* 4
,224 5
responseDto226 A
)22A B
;22B C
}33 	
[55 	
HttpGet55	 
]55 
[66 	
Route66	 
(66 
$str66 
)66 
]66  
public77 
async77 
Task77 
<77 
ActionResult77 &
<77& '
ResponseDTO77' 2
>772 3
>773 4
GetSubCategory775 C
(77C D
[77D E
	FromRoute77E N
]77N O
Guid77P T
id77U W
)77W X
{88 	
var99 
responseDto99 
=99 
await99 #
_categoryService99$ 4
.994 5
GetSubCategory995 C
(99C D
id99D F
)99F G
;99G H
return:: 

StatusCode:: 
(:: 
responseDto:: )
.::) *

StatusCode::* 4
,::4 5
responseDto::6 A
)::A B
;::B C
};; 	
[== 	
HttpGet==	 
]== 
[>> 	
Route>>	 
(>> 
$str>> !
)>>! "
]>>" #
public?? 
async?? 
Task?? 
<?? 
ActionResult?? &
<??& '
ResponseDTO??' 2
>??2 3
>??3 4
GetParentCategory??5 F
(??F G
[??G H
	FromRoute??H Q
]??Q R
Guid??S W
id??X Z
)??Z [
{@@ 	
varAA 
responseDtoAA 
=AA 
awaitAA #
_categoryServiceAA$ 4
.AA4 5
GetParentCategoryAA5 F
(AAF G
idAAG I
)AAI J
;AAJ K
returnBB 

StatusCodeBB 
(BB 
responseDtoBB )
.BB) *

StatusCodeBB* 4
,BB4 5
responseDtoBB6 A
)BBA B
;BBB C
}CC 	
[EE 	
HttpGetEE	 
]EE 
[FF 	
RouteFF	 
(FF 
$strFF 
)FF 
]FF 
[GG 	
	AuthorizeGG	 
]GG 
publicHH 
asyncHH 
TaskHH 
<HH 
ActionResultHH &
<HH& '
ResponseDTOHH' 2
>HH2 3
>HH3 4
GetByIdHH5 <
(HH< =
[HH= >
	FromRouteHH> G
]HHG H
GuidHHI M
idHHN P
)HHP Q
{II 	
varJJ 

responeDtoJJ 
=JJ 
awaitJJ "
_categoryServiceJJ# 3
.JJ3 4
GetJJ4 7
(JJ7 8
UserJJ8 <
,JJ< =
idJJ> @
)JJ@ A
;JJA B
returnKK 

StatusCodeKK 
(KK 

responeDtoKK (
.KK( )

StatusCodeKK) 3
,KK3 4

responeDtoKK5 ?
)KK? @
;KK@ A
}LL 	
[OO 	
HttpPostOO	 
]OO 
[PP 	
	AuthorizePP	 
(PP 
RolesPP 
=PP 
StaticUserRolesPP *
.PP* +
AdminPP+ 0
)PP0 1
]PP1 2
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ActionResultQQ &
<QQ& '
ResponseDTOQQ' 2
>QQ2 3
>QQ3 4
CreateQQ5 ;
(QQ; <
CreateCategoryDTOQQ< M
createCategoryDtoQQN _
)QQ_ `
{RR 	
varSS 

responeDtoSS 
=SS 
awaitSS "
_categoryServiceSS# 3
.SS3 4
CreateCategorySS4 B
(SSB C
UserSSC G
,SSG H
createCategoryDtoSSI Z
)SSZ [
;SS[ \
returnTT 

StatusCodeTT 
(TT 

responeDtoTT (
.TT( )

StatusCodeTT) 3
,TT3 4

responeDtoTT5 ?
)TT? @
;TT@ A
}UU 	
[WW 	
HttpPutWW	 
]WW 
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
>YY3 4
UpdateYY5 ;
(YY; <
[YY< =
FromBodyYY= E
]YYE F
UpdateCategoryDTOYYG X
updateCategoryDtoYYY j
)YYj k
{ZZ 	
var[[ 

responeDto[[ 
=[[ 
await[[ "
_categoryService[[# 3
.[[3 4
Update[[4 :
([[: ;
User[[; ?
,[[? @
updateCategoryDto[[A R
)[[R S
;[[S T
return\\ 

StatusCode\\ 
(\\ 

responeDto\\ (
.\\( )

StatusCode\\) 3
,\\3 4

responeDto\\5 ?
)\\? @
;\\@ A
}]] 	
[__ 	

HttpDelete__	 
]__ 
[`` 	
Route``	 
(`` 
$str`` 
)`` 
]`` 
[aa 	
	Authorizeaa	 
(aa 
Rolesaa 
=aa 
StaticUserRolesaa *
.aa* +
Adminaa+ 0
)aa0 1
]aa1 2
publicbb 
asyncbb 
Taskbb 
<bb 
ActionResultbb &
<bb& '
ResponseDTObb' 2
>bb2 3
>bb3 4
Deletebb5 ;
(bb; <
[bb< =
	FromRoutebb= F
]bbF G
GuidbbH L
idbbM O
)bbO P
{cc 	
vardd 

responeDtodd 
=dd 
awaitdd "
_categoryServicedd# 3
.dd3 4
Deletedd4 :
(dd: ;
Userdd; ?
,dd? @
idddA C
)ddC D
;ddD E
returnee 

StatusCodeee 
(ee 

responeDtoee (
.ee( )

StatusCodeee) 3
,ee3 4

responeDtoee5 ?
)ee? @
;ee@ A
}ff 	
}gg 
}hh ÷á
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
{## 	
var$$ 
responseDto$$ 
=$$ 
new$$ !
ResponseDTO$$" -
($$- .
)$$. /
;$$/ 0
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
ÄÄ 
return
ÅÅ 
NotFound
ÅÅ 
(
ÅÅ  
$str
ÅÅ  =
)
ÅÅ= >
;
ÅÅ> ?
}
ÇÇ 
if
ÑÑ 
(
ÑÑ 
Download
ÑÑ 
)
ÑÑ 
{
ÖÖ 
return
ÜÜ 
File
ÜÜ 
(
ÜÜ 
degreeResponseDto
ÜÜ -
.
ÜÜ- .
Stream
ÜÜ. 4
,
ÜÜ4 5
degreeResponseDto
ÜÜ6 G
.
ÜÜG H
ContentType
ÜÜH S
,
ÜÜS T
degreeResponseDto
ÜÜU f
.
ÜÜf g
FileName
ÜÜg o
)
ÜÜo p
;
ÜÜp q
}
áá 
return
ââ 
File
ââ 
(
ââ 
degreeResponseDto
ââ )
.
ââ) *
Stream
ââ* 0
,
ââ0 1
degreeResponseDto
ââ2 C
.
ââC D
ContentType
ââD O
)
ââO P
;
ââP Q
}
ää 	
[
ëë 	
HttpPost
ëë	 
]
ëë 
[
íí 	
Route
íí	 
(
íí 
$str
íí 
)
íí 
]
íí 
[
ìì 	
	Authorize
ìì	 
]
ìì 
public
îî 
async
îî 
Task
îî 
<
îî 
ActionResult
îî &
<
îî& '
ResponseDTO
îî' 2
>
îî2 3
>
îî3 4
UploadUserAvatar
îî5 E
(
îîE F
AvatarUploadDTO
îîF U
avatarUploadDto
îîV e
)
îîe f
{
ïï 	
var
ññ 
response
ññ 
=
ññ 
await
ññ  
_authService
ññ! -
.
ññ- .
UploadUserAvatar
ññ. >
(
ññ> ?
avatarUploadDto
ññ? N
.
ññN O
File
ññO S
,
ññS T
User
ññU Y
)
ññY Z
;
ññZ [
return
óó 

StatusCode
óó 
(
óó 
response
óó &
.
óó& '

StatusCode
óó' 1
,
óó1 2
response
óó3 ;
)
óó; <
;
óó< =
}
òò 	
[
ûû 	
HttpGet
ûû	 
]
ûû 
[
üü 	
Route
üü	 
(
üü 
$str
üü 
)
üü 
]
üü 
[
†† 	
	Authorize
††	 
]
†† 
public
°° 
async
°° 
Task
°° 
<
°° 
IActionResult
°° '
>
°°' (
GetUserAvatar
°°) 6
(
°°6 7
)
°°7 8
{
¢¢ 	
var
££ 
stream
££ 
=
££ 
await
££ 
_authService
££ +
.
££+ ,
GetUserAvatar
££, 9
(
££9 :
User
££: >
)
££> ?
;
££? @
if
§§ 
(
§§ 
stream
§§ 
is
§§ 
null
§§ 
)
§§ 
{
•• 
return
¶¶ 
NotFound
¶¶ 
(
¶¶  
$str
¶¶  =
)
¶¶= >
;
¶¶> ?
}
ßß 
return
©© 
File
©© 
(
©© 
stream
©© 
,
©© 
$str
©©  +
)
©©+ ,
;
©©, -
}
™™ 	
[
∞∞ 	
HttpGet
∞∞	 
]
∞∞ 
[
±± 	
Route
±±	 
(
±± 
$str
±± -
)
±±- .
]
±±. /
public
≤≤ 
async
≤≤ 
Task
≤≤ 
<
≤≤ 
IActionResult
≤≤ '
>
≤≤' (
DisplayUserAvatar
≤≤) :
(
≤≤: ;
[
≤≤; <
	FromRoute
≤≤< E
]
≤≤E F
string
≤≤G M
userId
≤≤N T
)
≤≤T U
{
≥≥ 	
var
¥¥ 
stream
¥¥ 
=
¥¥ 
await
¥¥ 
_authService
¥¥ +
.
¥¥+ ,
DisplayUserAvatar
¥¥, =
(
¥¥= >
userId
¥¥> D
)
¥¥D E
;
¥¥E F
if
µµ 
(
µµ 
stream
µµ 
is
µµ 
null
µµ 
)
µµ 
{
∂∂ 
return
∑∑ 
NotFound
∑∑ 
(
∑∑  
$str
∑∑  =
)
∑∑= >
;
∑∑> ?
}
∏∏ 
return
∫∫ 
File
∫∫ 
(
∫∫ 
stream
∫∫ 
,
∫∫ 
$str
∫∫  +
)
∫∫+ ,
;
∫∫, -
}
ªª 	
[
¡¡ 	
HttpPost
¡¡	 
]
¡¡ 
[
¬¬ 	
Route
¬¬	 
(
¬¬ 
$str
¬¬  
)
¬¬  !
]
¬¬! "
public
√√ 
async
√√ 
Task
√√ 
<
√√ 
ActionResult
√√ &
<
√√& '
ResponseDTO
√√' 2
>
√√2 3
>
√√3 4
ForgotPassword
√√5 C
(
√√C D
[
√√D E
FromBody
√√E M
]
√√M N
ForgotPasswordDTO
√√O `
forgotPasswordDto
√√a r
)
√√r s
{
ƒƒ 	
var
≈≈ 
result
≈≈ 
=
≈≈ 
await
≈≈ 
_authService
≈≈ +
.
≈≈+ ,
ForgotPassword
≈≈, :
(
≈≈: ;
forgotPasswordDto
≈≈; L
)
≈≈L M
;
≈≈M N
return
∆∆ 

StatusCode
∆∆ 
(
∆∆ 
result
∆∆ $
.
∆∆$ %

StatusCode
∆∆% /
,
∆∆/ 0
result
∆∆1 7
)
∆∆7 8
;
∆∆8 9
}
«« 	
[
ÕÕ 	
HttpPost
ÕÕ	 
(
ÕÕ 
$str
ÕÕ "
)
ÕÕ" #
]
ÕÕ# $
public
ŒŒ 
async
ŒŒ 
Task
ŒŒ 
<
ŒŒ 
ActionResult
ŒŒ &
<
ŒŒ& '
ResponseDTO
ŒŒ' 2
>
ŒŒ2 3
>
ŒŒ3 4
ResetPassword
ŒŒ5 B
(
ŒŒB C
[
ŒŒC D
FromBody
ŒŒD L
]
ŒŒL M
ResetPasswordDTO
ŒŒN ^
resetPasswordDto
ŒŒ_ o
)
ŒŒo p
{
œœ 	
var
–– 
result
–– 
=
–– 
await
–– 
_authService
–– +
.
––+ ,
ResetPassword
––, 9
(
––9 :
resetPasswordDto
––: J
.
––J K
Email
––K P
,
––P Q
resetPasswordDto
––R b
.
––b c
Token
––c h
,
––h i
resetPasswordDto
——  
.
——  !
Password
——! )
)
——) *
;
——* +
return
““ 

StatusCode
““ 
(
““ 
result
““ $
.
““$ %

StatusCode
““% /
,
““/ 0
result
““1 7
)
““7 8
;
““8 9
}
”” 	
[
⁄⁄ 	
HttpPost
⁄⁄	 
]
⁄⁄ 
[
€€ 	
Route
€€	 
(
€€ 
$str
€€ "
)
€€" #
]
€€# $
public
‹‹ 
async
‹‹ 
Task
‹‹ 
<
‹‹ 
ActionResult
‹‹ &
<
‹‹& '
ResponseDTO
‹‹' 2
>
‹‹2 3
>
‹‹3 4
SendVerifyEmail
‹‹5 D
(
‹‹D E
[
‹‹E F
FromBody
‹‹F N
]
‹‹N O 
SendVerifyEmailDTO
‹‹P b
email
‹‹c h
)
‹‹h i
{
›› 	
var
ﬁﬁ 
user
ﬁﬁ 
=
ﬁﬁ 
await
ﬁﬁ 
_userManager
ﬁﬁ )
.
ﬁﬁ) *
FindByEmailAsync
ﬁﬁ* :
(
ﬁﬁ: ;
email
ﬁﬁ; @
.
ﬁﬁ@ A
Email
ﬁﬁA F
)
ﬁﬁF G
;
ﬁﬁG H
if
ﬂﬂ 
(
ﬂﬂ 
user
ﬂﬂ 
.
ﬂﬂ 
EmailConfirmed
ﬂﬂ #
)
ﬂﬂ# $
{
‡‡ 
return
·· 
new
·· 
ResponseDTO
·· &
(
··& '
)
··' (
{
‚‚ 
	IsSuccess
„„ 
=
„„ 
true
„„  $
,
„„$ %
Message
‰‰ 
=
‰‰ 
$str
‰‰ =
,
‰‰= >

StatusCode
ÂÂ 
=
ÂÂ  
$num
ÂÂ! $
,
ÂÂ$ %
Result
ÊÊ 
=
ÊÊ 
email
ÊÊ "
}
ÁÁ 
;
ÁÁ 
}
ËË 
var
ÍÍ 
token
ÍÍ 
=
ÍÍ 
await
ÍÍ 
_userManager
ÍÍ *
.
ÍÍ* +1
#GenerateEmailConfirmationTokenAsync
ÍÍ+ N
(
ÍÍN O
user
ÍÍO S
)
ÍÍS T
;
ÍÍT U
var
ÏÏ 
confirmationLink
ÏÏ  
=
ÏÏ! "
$"
ÌÌ 
$str
ÌÌ N
{
ÌÌN O
user
ÌÌO S
.
ÌÌS T
Id
ÌÌT V
}
ÌÌV W
$str
ÌÌW ^
{
ÌÌ^ _
Uri
ÌÌ_ b
.
ÌÌb c
EscapeDataString
ÌÌc s
(
ÌÌs t
token
ÌÌt y
)
ÌÌy z
}
ÌÌz {
"
ÌÌ{ |
;
ÌÌ| }
var
ÔÔ 
responseDto
ÔÔ 
=
ÔÔ 
await
ÔÔ #
_authService
ÔÔ$ 0
.
ÔÔ0 1
SendVerifyEmail
ÔÔ1 @
(
ÔÔ@ A
user
ÔÔA E
.
ÔÔE F
Email
ÔÔF K
,
ÔÔK L
confirmationLink
ÔÔM ]
)
ÔÔ] ^
;
ÔÔ^ _
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
ÙÙ 	
HttpPost
ÙÙ	 
]
ÙÙ 
[
ıı 	
Route
ıı	 
(
ıı 
$str
ıı 
)
ıı 
]
ıı 
[
ˆˆ 	

ActionName
ˆˆ	 
(
ˆˆ 
$str
ˆˆ "
)
ˆˆ" #
]
ˆˆ# $
public
˜˜ 
async
˜˜ 
Task
˜˜ 
<
˜˜ 
ActionResult
˜˜ &
<
˜˜& '
ResponseDTO
˜˜' 2
>
˜˜2 3
>
˜˜3 4
VerifyEmail
˜˜5 @
(
˜˜@ A
[
¯¯ 
	FromQuery
¯¯ 
]
¯¯ 
string
¯¯ 
userId
¯¯ %
,
¯¯% &
[
˘˘ 
	FromQuery
˘˘ 
]
˘˘ 
string
˘˘ 
token
˘˘ $
)
˘˘$ %
{
˙˙ 	
var
˚˚ 
responseDto
˚˚ 
=
˚˚ 
await
˚˚ #
_authService
˚˚$ 0
.
˚˚0 1
VerifyEmail
˚˚1 <
(
˚˚< =
userId
˚˚= C
,
˚˚C D
token
˚˚E J
)
˚˚J K
;
˚˚K L
return
¸¸ 

StatusCode
¸¸ 
(
¸¸ 
responseDto
¸¸ )
.
¸¸) *

StatusCode
¸¸* 4
,
¸¸4 5
responseDto
¸¸6 A
)
¸¸A B
;
¸¸B C
}
˝˝ 	
[
ÉÉ 	
HttpPost
ÉÉ	 
]
ÉÉ 
[
ÑÑ 	
Route
ÑÑ	 
(
ÑÑ 
$str
ÑÑ  
)
ÑÑ  !
]
ÑÑ! "
[
ÖÖ 	
	Authorize
ÖÖ	 
]
ÖÖ 
public
ÜÜ 
async
ÜÜ 
Task
ÜÜ 
<
ÜÜ 
ActionResult
ÜÜ &
<
ÜÜ& '
ResponseDTO
ÜÜ' 2
>
ÜÜ2 3
>
ÜÜ3 4
ChangePassword
ÜÜ5 C
(
ÜÜC D
ChangePasswordDTO
ÜÜD U
changePasswordDto
ÜÜV g
)
ÜÜg h
{
áá 	
var
ââ 
userId
ââ 
=
ââ 
User
ââ 
.
ââ 
FindFirstValue
ââ ,
(
ââ, -

ClaimTypes
ââ- 7
.
ââ7 8
NameIdentifier
ââ8 F
)
ââF G
;
ââG H
var
ãã 
response
ãã 
=
ãã 
await
ãã  
_authService
ãã! -
.
ãã- .
ChangePassword
ãã. <
(
ãã< =
userId
ãã= C
,
ããC D
changePasswordDto
ããE V
.
ããV W
OldPassword
ããW b
,
ããb c
changePasswordDto
åå !
.
åå! "
NewPassword
åå" -
,
åå- .
changePasswordDto
åå/ @
.
åå@ A 
ConfirmNewPassword
ååA S
)
ååS T
;
ååT U
if
éé 
(
éé 
response
éé 
.
éé 
	IsSuccess
éé "
)
éé" #
{
èè 
return
êê 
Ok
êê 
(
êê 
response
êê "
.
êê" #
Message
êê# *
)
êê* +
;
êê+ ,
}
ëë 
else
íí 
{
ìì 
return
îî 

BadRequest
îî !
(
îî! "
response
îî" *
.
îî* +
Message
îî+ 2
)
îî2 3
;
îî3 4
}
ïï 
}
ññ 	
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
ûû 
)
ûû 
]
ûû 
public
üü 
async
üü 
Task
üü 
<
üü 
ActionResult
üü &
<
üü& '
ResponseDTO
üü' 2
>
üü2 3
>
üü3 4
SignIn
üü5 ;
(
üü; <
[
üü< =
FromBody
üü= E
]
üüE F
SignDTO
üüG N
signDto
üüO V
)
üüV W
{
†† 	
var
°° 
responseDto
°° 
=
°° 
await
°° #
_authService
°°$ 0
.
°°0 1
SignIn
°°1 7
(
°°7 8
signDto
°°8 ?
)
°°? @
;
°°@ A
return
¢¢ 

StatusCode
¢¢ 
(
¢¢ 
responseDto
¢¢ )
.
¢¢) *

StatusCode
¢¢* 4
,
¢¢4 5
responseDto
¢¢6 A
)
¢¢A B
;
¢¢B C
}
££ 	
[
¶¶ 	
HttpPost
¶¶	 
]
¶¶ 
[
ßß 	
Route
ßß	 
(
ßß 
$str
ßß 
)
ßß 
]
ßß 
public
®® 
async
®® 
Task
®® 
<
®® 
ActionResult
®® &
<
®®& '
ResponseDTO
®®' 2
>
®®2 3
>
®®3 4
Refresh
®®5 <
(
®®< =
[
®®= >
FromBody
®®> F
]
®®F G
JwtTokenDTO
®®H S
token
®®T Y
)
®®Y Z
{
©© 	
var
™™ 
responseDto
™™ 
=
™™ 
await
™™ #
_authService
™™$ 0
.
™™0 1
Refresh
™™1 8
(
™™8 9
token
™™9 >
.
™™> ?
RefreshToken
™™? K
)
™™K L
;
™™L M
return
´´ 

StatusCode
´´ 
(
´´ 
responseDto
´´ )
.
´´) *

StatusCode
´´* 4
,
´´4 5
responseDto
´´6 A
)
´´A B
;
´´B C
}
¨¨ 	
[
ÆÆ 	
HttpPost
ÆÆ	 
]
ÆÆ 
[
ØØ 	
Route
ØØ	 
(
ØØ 
$str
ØØ "
)
ØØ" #
]
ØØ# $
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
ActionResult
∞∞ &
<
∞∞& '
ResponseDTO
∞∞' 2
>
∞∞2 3
>
∞∞3 4
CheckEmailExist
∞∞5 D
(
∞∞D E
[
∞∞E F
FromBody
∞∞F N
]
∞∞N O
string
∞∞P V
email
∞∞W \
)
∞∞\ ]
{
±± 	
var
≤≤ 
responseDto
≤≤ 
=
≤≤ 
await
≤≤ #
_authService
≤≤$ 0
.
≤≤0 1
CheckEmailExist
≤≤1 @
(
≤≤@ A
email
≤≤A F
)
≤≤F G
;
≤≤G H
return
≥≥ 

StatusCode
≥≥ 
(
≥≥ 
responseDto
≥≥ )
.
≥≥) *

StatusCode
≥≥* 4
,
≥≥4 5
responseDto
≥≥6 A
)
≥≥A B
;
≥≥B C
}
¥¥ 	
[
∂∂ 	
HttpPost
∂∂	 
]
∂∂ 
[
∑∑ 	
Route
∑∑	 
(
∑∑ 
$str
∑∑ )
)
∑∑) *
]
∑∑* +
public
∏∏ 
async
∏∏ 
Task
∏∏ 
<
∏∏ 
ActionResult
∏∏ &
<
∏∏& '
ResponseDTO
∏∏' 2
>
∏∏2 3
>
∏∏3 4#
CheckPhoneNumberExist
∏∏5 J
(
∏∏J K
[
∏∏K L
FromBody
∏∏L T
]
∏∏T U
string
∏∏V \
phoneNumber
∏∏] h
)
∏∏h i
{
ππ 	
var
∫∫ 
responseDto
∫∫ 
=
∫∫ 
await
∫∫ #
_authService
∫∫$ 0
.
∫∫0 1#
CheckPhoneNumberExist
∫∫1 F
(
∫∫F G
phoneNumber
∫∫G R
)
∫∫R S
;
∫∫S T
return
ªª 

StatusCode
ªª 
(
ªª 
responseDto
ªª )
.
ªª) *

StatusCode
ªª* 4
,
ªª4 5
responseDto
ªª6 A
)
ªªA B
;
ªªB C
}
ºº 	
[
øø 	
HttpPost
øø	 
]
øø 
[
¿¿ 	
Route
¿¿	 
(
¿¿ 
$str
¿¿  
)
¿¿  !
]
¿¿! "
[
¡¡ 	
	Authorize
¡¡	 
]
¡¡ 
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
¬¬3 4$
CompleteStudentProfile
¬¬5 K
(
¬¬K L'
CompleteStudentProfileDTO
√√ %'
completeStudentProfileDto
√√& ?
)
√√? @
{
ƒƒ 	
var
≈≈ 
responseDto
≈≈ 
=
≈≈ 
await
≈≈ #
_authService
≈≈$ 0
.
≈≈0 1$
CompleteStudentProfile
≈≈1 G
(
≈≈G H
User
≈≈H L
,
≈≈L M'
completeStudentProfileDto
≈≈N g
)
≈≈g h
;
≈≈h i
return
∆∆ 

StatusCode
∆∆ 
(
∆∆ 
responseDto
∆∆ )
.
∆∆) *

StatusCode
∆∆* 4
,
∆∆4 5
responseDto
∆∆6 A
)
∆∆A B
;
∆∆B C
}
«« 	
[
…… 	
HttpPost
……	 
]
…… 
[
   	
Route
  	 
(
   
$str
   #
)
  # $
]
  $ %
[
ÀÀ 	
	Authorize
ÀÀ	 
]
ÀÀ 
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
<
ÃÃ 
ActionResult
ÃÃ &
<
ÃÃ& '
ResponseDTO
ÃÃ' 2
>
ÃÃ2 3
>
ÃÃ3 4'
CompleteInstructorProfile
ÃÃ5 N
(
ÃÃN O*
CompleteInstructorProfileDTO
ÕÕ (*
completeInstructorProfileDto
ÕÕ) E
)
ÕÕE F
{
ŒŒ 	
var
œœ 
responseDto
œœ 
=
œœ 
await
œœ #
_authService
œœ$ 0
.
œœ0 1'
CompleteInstructorProfile
œœ1 J
(
œœJ K
User
œœK O
,
œœO P*
completeInstructorProfileDto
œœQ m
)
œœm n
;
œœn o
return
–– 

StatusCode
–– 
(
–– 
responseDto
–– )
.
––) *

StatusCode
––* 4
,
––4 5
responseDto
––6 A
)
––A B
;
––B C
}
—— 	
[
”” 	
HttpPost
””	 
]
”” 
[
‘‘ 	
Route
‘‘	 
(
‘‘ 
$str
‘‘ 
)
‘‘  
]
‘‘  !
public
’’ 
async
’’ 
Task
’’ 
<
’’ 
ActionResult
’’ &
<
’’& '
ResponseDTO
’’' 2
>
’’2 3
>
’’3 4
SignInByGoogle
’’5 C
(
’’C D
SignInByGoogleDTO
’’D U
signInByGoogleDto
’’V g
)
’’g h
{
÷÷ 	
var
◊◊ 
response
◊◊ 
=
◊◊ 
await
◊◊  
_authService
◊◊! -
.
◊◊- .
SignInByGoogle
◊◊. <
(
◊◊< =
signInByGoogleDto
◊◊= N
)
◊◊N O
;
◊◊O P
return
ÿÿ 

StatusCode
ÿÿ 
(
ÿÿ 
response
ÿÿ &
.
ÿÿ& '

StatusCode
ÿÿ' 1
,
ÿÿ1 2
response
ÿÿ3 ;
)
ÿÿ; <
;
ÿÿ< =
}
ŸŸ 	
[
€€ 	
HttpGet
€€	 
]
€€ 
[
‹‹ 	
Route
‹‹	 
(
‹‹ 
$str
‹‹ 
)
‹‹ 
]
‹‹ 
public
›› 
async
›› 
Task
›› 
<
›› 
ActionResult
›› &
<
››& '
ResponseDTO
››' 2
>
››2 3
>
››3 4
GetUserInfo
››5 @
(
››@ A
)
››A B
{
ﬁﬁ 	
var
ﬂﬂ 
response
ﬂﬂ 
=
ﬂﬂ 
await
ﬂﬂ  
_authService
ﬂﬂ! -
.
ﬂﬂ- .
GetUserInfo
ﬂﬂ. 9
(
ﬂﬂ9 :
User
ﬂﬂ: >
)
ﬂﬂ> ?
;
ﬂﬂ? @
return
‡‡ 

StatusCode
‡‡ 
(
‡‡ 
response
‡‡ &
.
‡‡& '

StatusCode
‡‡' 1
,
‡‡1 2
response
‡‡3 ;
)
‡‡; <
;
‡‡< =
}
·· 	
[
„„ 	
HttpPut
„„	 
]
„„ 
[
‰‰ 	
Route
‰‰	 
(
‰‰ 
$str
‰‰  
)
‰‰  !
]
‰‰! "
public
ÂÂ 
async
ÂÂ 
Task
ÂÂ 
<
ÂÂ 
ActionResult
ÂÂ &
<
ÂÂ& '
ResponseDTO
ÂÂ' 2
>
ÂÂ2 3
>
ÂÂ3 4
UpdateStudent
ÂÂ5 B
(
ÂÂB C
[
ÂÂC D
FromBody
ÂÂD L
]
ÂÂL M%
UpdateStudentProfileDTO
ÂÂN e

studentDto
ÂÂf p
)
ÂÂp q
{
ÊÊ 	
var
ÁÁ 
responseDto
ÁÁ 
=
ÁÁ 
await
ÁÁ #
_authService
ÁÁ$ 0
.
ÁÁ0 1
UpdateStudent
ÁÁ1 >
(
ÁÁ> ?

studentDto
ÁÁ? I
,
ÁÁI J
User
ÁÁK O
)
ÁÁO P
;
ÁÁP Q
return
ËË 

StatusCode
ËË 
(
ËË 
responseDto
ËË )
.
ËË) *

StatusCode
ËË* 4
,
ËË4 5
responseDto
ËË6 A
)
ËËA B
;
ËËB C
}
ÈÈ 	
[
ÎÎ 	
HttpPut
ÎÎ	 
]
ÎÎ 
[
ÏÏ 	
Route
ÏÏ	 
(
ÏÏ 
$str
ÏÏ #
)
ÏÏ# $
]
ÏÏ$ %
public
ÌÌ 
async
ÌÌ 
Task
ÌÌ 
<
ÌÌ 
ActionResult
ÌÌ &
<
ÌÌ& '
ResponseDTO
ÌÌ' 2
>
ÌÌ2 3
>
ÌÌ3 4
UpdateInstructor
ÌÌ5 E
(
ÌÌE F
[
ÓÓ 
FromBody
ÓÓ 
]
ÓÓ '
UpdateIntructorProfileDTO
ÓÓ 0
instructorDto
ÓÓ1 >
)
ÓÓ> ?
{
ÔÔ 	
var
 
responseDto
 
=
 
await
 #
_authService
$ 0
.
0 1
UpdateInstructor
1 A
(
A B
instructorDto
B O
,
O P
User
Q U
)
U V
;
V W
return
ÒÒ 

StatusCode
ÒÒ 
(
ÒÒ 
responseDto
ÒÒ )
.
ÒÒ) *

StatusCode
ÒÒ* 4
,
ÒÒ4 5
responseDto
ÒÒ6 A
)
ÒÒA B
;
ÒÒB C
}
ÚÚ 	
[
ÙÙ 	
HttpPost
ÙÙ	 
]
ÙÙ 
[
ıı 	
Route
ıı	 
(
ıı 
$str
ıı 
)
ıı 
]
ıı 
[
ˆˆ 	
	Authorize
ˆˆ	 
(
ˆˆ 
Roles
ˆˆ 
=
ˆˆ 
StaticUserRoles
ˆˆ *
.
ˆˆ* +
Admin
ˆˆ+ 0
)
ˆˆ0 1
]
ˆˆ1 2
public
˜˜ 
async
˜˜ 
Task
˜˜ 
<
˜˜ 
ActionResult
˜˜ &
<
˜˜& '
ResponseDTO
˜˜' 2
>
˜˜2 3
>
˜˜3 4
LockUser
˜˜5 =
(
˜˜= >
[
˜˜> ?
FromBody
˜˜? G
]
˜˜G H
LockUserDTO
˜˜I T
lockUserDto
˜˜U `
)
˜˜` a
{
¯¯ 	
var
˘˘ 
responseDto
˘˘ 
=
˘˘ 
await
˘˘ #
_authService
˘˘$ 0
.
˘˘0 1
LockUser
˘˘1 9
(
˘˘9 :
lockUserDto
˘˘: E
)
˘˘E F
;
˘˘F G
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
˝˝ 	
HttpPost
˝˝	 
]
˝˝ 
[
˛˛ 	
Route
˛˛	 
(
˛˛ 
$str
˛˛ 
)
˛˛ 
]
˛˛ 
[
ˇˇ 	
	Authorize
ˇˇ	 
(
ˇˇ 
Roles
ˇˇ 
=
ˇˇ 
StaticUserRoles
ˇˇ *
.
ˇˇ* +
Admin
ˇˇ+ 0
)
ˇˇ0 1
]
ˇˇ1 2
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
<
ÄÄ 
ActionResult
ÄÄ &
<
ÄÄ& '
ResponseDTO
ÄÄ' 2
>
ÄÄ2 3
>
ÄÄ3 4

UnlockUser
ÄÄ5 ?
(
ÄÄ? @
[
ÄÄ@ A
FromBody
ÄÄA I
]
ÄÄI J
LockUserDTO
ÄÄK V
lockUserDto
ÄÄW b
)
ÄÄb c
{
ÅÅ 	
var
ÇÇ 
responseDto
ÇÇ 
=
ÇÇ 
await
ÇÇ #
_authService
ÇÇ$ 0
.
ÇÇ0 1

UnlockUser
ÇÇ1 ;
(
ÇÇ; <
lockUserDto
ÇÇ< G
)
ÇÇG H
;
ÇÇH I
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
}
ÖÖ 
}ÜÜ 