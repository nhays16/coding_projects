# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse

from models import *
from django.core import serializers

def index(request):
    return render(request, 'user_login/index.html')

def all_json(request):
    users = User.objects.all()
    users_json = serializers.serialize('json', users)
#    print users_json
    return HttpResponse(users_json, content_type='application/json')

def all_html(request):
    users = User.objects.all()
    return render(request, 'user_login/all.html', {'users': users})

def find(request):
    users = User.objects.filter(first_name__startswith=request.POST['first_name_starts_with']
#    print users
    return render(request, 'user_login/all.html', {'users': users})

def create(request):
    User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email_address=request.POST['email_address'])
    users = User.objects.order_by('-id')
    return render(request, 'user_login/all.html', {'users': users})