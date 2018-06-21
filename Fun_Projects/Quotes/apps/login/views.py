# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse

from django.contrib import messages
from .models import User

def index(request):
    if 'user_id' in request.session:
        return redirect('/quotes')
    return render(request, 'login/index.html')

def register(request):
    if 'user_id' in request.session:
        return redirect('/quotes')
    errors = User.objects.validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/main')
    else:
        password = User.objects.password_hash(request.POST['password'])
        User.objects.create(
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            alias = request.POST['alias'],
            email = request.POST['email'],
            password = password,
            birthday = request.POST['birthday']
        )
        new_user = User.objects.last()
        request.session['user_id'] = new_user.id
        request.session['name'] = new_user.first_name
        return redirect('/quotes')

def login(request):
    errors = User.objects.login_validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/main')
    else:
        user = User.objects.filter(email=request.POST['email'])
        if len(user) > 0:
            name = user[0].first_name
            request.session['name'] = name
            request.session['user_id']=user[0].id #added [0] back in for now
            return redirect('/quotes')
        else:
            messages.error(request, 'Login info does not match database- please try again or please register')
            return redirect('/main')

def logout(request):
    request.session.clear()
    return redirect('/main')


