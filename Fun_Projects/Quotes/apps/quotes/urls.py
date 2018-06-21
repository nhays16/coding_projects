from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^quotes$', views.dashboard),
    url(r'^users/(?P<user_id>\d+)$', views.user_info),    
    url(r'^quotes/create$', views.quote_create),
    url(r'^fave/add/(?P<quote_id>\d+)$', views.add_fave),
    url(r'^fave/remove/(?P<quote_id>\d+)$', views.remove_fave)
]